using System;
using System.Collections.Generic;
using System.Linq;
using EleWise.ELMA.CRM.Managers;
using EleWise.ELMA.CRM.Models;
using EleWise.ELMA.Extensions;
using EleWise.ELMA.Logging;
using EleWise.ELMA.Model.Managers;
using EleWise.ELMA.Model.Services;
using EleWise.ELMA.Runtime.NH;
using EleWise.ELMA.Security;
using EleWise.ELMA.Security.Managers;
using EleWise.ELMA.Services;
using NHibernate;
using Yambr.ELMA.Email.Common.Models;
using Yambr.ELMA.Email.Models;
using IContact = EleWise.ELMA.CRM.Models.IContact;
using IContractor = EleWise.ELMA.CRM.Models.IContractor;

namespace Yambr.ELMA.Email.Managers
{
    public class EmailMessageParticipantManager : EntityManager<IEmailMessageParticipant, long>
    {
        private readonly ISessionProvider _sessionProvider;

        private static readonly ILogger Logger = EmailLogger.Logger;

        public EmailMessageParticipantManager(
            ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }
        private static EmailMessageParticipantManager _manager;

        public new static EmailMessageParticipantManager Instance => _manager ?? (_manager = Locator.GetServiceNotNull<EmailMessageParticipantManager>());

        public IEmailMessageParticipant Load(string email)
        {
            var guid = GetUid(email);
            return LoadOrNull(guid);
        }

        public static Guid GetUid(string email)
        {
            return email.GetDeterministicGuid();
        }

        public override void Save(IEmailMessageParticipant obj)
        {
            obj.Uid = GetUid(obj.EmailString);
            obj.Name = GetName(obj);
            base.Save(obj);
        }

        private string GetName(IEmailMessageParticipant emailMessageParticipant)
        {
            //TODO переделать на автовычисление
            return $"{emailMessageParticipant.EmailString}";
        }

        public ICollection<IEmailMessageParticipant> GetParticipants(ICollection<string> email)
        {
            var session = _sessionProvider.GetSession("");

            var emailsString = string.Join(",", email.Select(c => $"'{c.GetDeterministicGuid()}'"));

            // Тут будут все участники писем - контакты и наши полльзователи
            var hqlQuery =
                session.CreateQuery(
                    "select emailParticipant FROM EmailMessageParticipant emailParticipant " +
                    $"where emailParticipant.Uid in ({emailsString})");
            hqlQuery.SetMaxResults(email.Count);
            return hqlQuery.List<IEmailMessageParticipant>();
        }

        /// <summary>
        /// Создать участников (участники - пользователи уже созданы автоматом)
        /// </summary>
        /// <param name="contactSummaries"></param>
        /// <returns></returns>
        public ICollection<IEmailMessageParticipant> CreateParticipants( ICollection<ContactSummary> contactSummaries)
        {
            var emails = contactSummaries.Select(c => c.Email).ToList();
            var session = _sessionProvider.GetSession("");

            var emailsString = string.Join(",", emails.Select(c => $"'{c}'"));

            var existContacts = GetContacts(session, emailsString).ToList();
            var notExistingContactSummaries = contactSummaries.Where(c =>
                existContacts
                    .All(
                        ec => ec.Email.All(
                            ecm => ecm.EmailString != c.Email))).ToList();
            var newContacts = CreateContacts(session, notExistingContactSummaries);
            existContacts.AddRange(newContacts);

            return CreateParticipants(contactSummaries, existContacts);
        }



        private ICollection<IEmailMessageParticipant> CreateParticipants(ICollection<ContactSummary> contactSummaries, ICollection<IContact> contacts)
        {
            // участников создаем, контрагенты и контакты уже созданы
            var emailMessageParticipants = new List<IEmailMessageParticipant>();

            foreach (var contactSummary in contactSummaries)
            {
                var currentContacts =
                    contacts.Where(
                            c => c.Email.Any(
                                e => e.EmailString == contactSummary.Email)).ToList();
                //Контакты созданы заранее
                foreach (var currentContact in currentContacts)
                {
                    emailMessageParticipants.Add(CreateParticipant(contactSummary, currentContact));
                }
            }

            return emailMessageParticipants;
        }

        private IEmailMessageParticipant CreateParticipant(ContactSummary contactSummary, IContact currentContact)
        {
            var emailMessageParticipant = InterfaceActivator.Create<IEmailMessageParticipantContact>();
            emailMessageParticipant.Contact = currentContact;
            emailMessageParticipant.EmailString = contactSummary.Email;
            emailMessageParticipant.Save();
            if (Logger.IsDebugEnabled())
            {
                Logger.Log(LogLevel.Debug, $"Created ParticipantContact: {emailMessageParticipant.EmailString}");
            }

            return emailMessageParticipant;
        }

        private ICollection<IContact> CreateContacts(ISession session, List<ContactSummary> notExistingContactSummaries)
        { 

            var newContacts = new List<IContact>();
            var contractors = GetContractors(session, notExistingContactSummaries);
            if (contractors != null)
                foreach (var contractor in contractors)
                {
                    var forCreateContactSummaries = notExistingContactSummaries
                        .Where(c =>
                            contractor.Email.Any(ce => ce.EmailString == c.Email) ||
                            contractor.Domains.Any(d => d.Name == Domain(c.Email)))
                        .ToList();
                    if (forCreateContactSummaries.Any())
                    {
                        foreach (var forCreateContactSummary in forCreateContactSummaries)
                        {
                            var contact = CreateContact(contractor, forCreateContactSummary);
                            newContacts.Add(contact);
                            notExistingContactSummaries.Remove(forCreateContactSummary);
                        }
                    }
                }

            //TODO не создавать контрагентов в настройках
            if (notExistingContactSummaries.Any())
            {
               
                var contractorsToCreate = notExistingContactSummaries
                     .GroupBy(s => Domain(s.Email));

                foreach (var groupedByDomain in contractorsToCreate)
                {
                    var contacts = CreateContacts(groupedByDomain.Key, groupedByDomain.ToList());
                    newContacts.AddRange(contacts);
                }
            }

            return newContacts;
        }

        private static IEnumerable<IContact> CreateContacts(string domain, ICollection<ContactSummary> notExistingContactSummaries)
        {
            IContractor contractor = null;
            var publicDomains = PublicDomainManager.Instance.GetPublicDomains();
            if (!string.IsNullOrWhiteSpace(domain) && !publicDomains.Contains(domain))
            {
                contractor = CreateContractor(notExistingContactSummaries, domain);
            }

            return notExistingContactSummaries
                .Select(notExistingContactSummary => CreateContact(notExistingContactSummary, contractor)).ToList();
        }
        private static IContact CreateContact(ContactSummary notExistingContactSummary, IContractor contractor)
        {
            var contact = CreateContact(notExistingContactSummary);
            if (contractor != null)
            {
                contact.Contractor = contractor;
            }
            return contact;
        }
        private static IContact CreateContact(ContactSummary notExistingContactSummary)
        {
            var contact = InterfaceActivator.Create<IContact>();
            contact.Name = notExistingContactSummary.Fio;
            var email = InterfaceActivator.Create<IEmail>();
            email.EmailString = notExistingContactSummary.Email;
            contact.Email.Add(email);

            var fio = notExistingContactSummary.Fio;
            if (fio != null)
            {
                var names = fio.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                switch (names.Length)
                {
                    case 1:
                        contact.Firstname = fio;
                        break;
                    case 2:
                        contact.Firstname = names[0];
                        contact.Surname = names[1];
                        break;
                    case 3:
                        contact.Surname = names[0];
                        contact.Firstname = names[1];
                        contact.Middlename = names[2];
                        break;
                    default:
                        contact.Firstname = fio;
                        break;
                }
            }
            else
            {
                contact.Firstname = notExistingContactSummary.Email;
            }
            if (Logger.IsDebugEnabled())
            {
                Logger.Log(LogLevel.Debug, $"Created Contact: {notExistingContactSummary.Email}");
            }


            return contact;
        }
       

        private static IContractorExt CreateContractor(IEnumerable<ContactSummary> notExistingContactSummaries, string domain)
        {
            //Теоретчиески у всез у кого домены - все юрики
            var contractorLegal = (IContractorExt)InterfaceActivator.Create<IContractorLegal>();
         
            var mailboxDomain = InterfaceActivator.Create<IMailboxDomain>();
            mailboxDomain.Name = domain;
            mailboxDomain.Contractor = contractorLegal;
            mailboxDomain.Save();
            contractorLegal.Name = domain;
            contractorLegal.Responsible = UserManager.Instance.GetCurrentUser();
            contractorLegal.Domains.Add(mailboxDomain);
            ContractorManager.Instance.SaveWithCategoryRules(contractorLegal);

            if (Logger.IsDebugEnabled())
            {
                Logger.Log(LogLevel.Debug, $"Created ContractorLegal: {domain}");
            }
            return contractorLegal;
        }

        private static string Domain(string email)
        {
            return email.Split(new[] { '@' }, StringSplitOptions.None)[1]?.ToLowerInvariant();
        }

        private static IContact CreateContact(IContractor contractor, ContactSummary forCreateContactSummary)
        {
            var contact = CreateContact(forCreateContactSummary);
            contact.Contractor = contractor;
            return contact;
        }

        private IEnumerable<IContractorExt> GetContractors(ISession session, List<ContactSummary> notExistingContactSummaries)
        {
            if (notExistingContactSummaries == null)
                throw new ArgumentNullException(nameof(notExistingContactSummaries));
            if (!notExistingContactSummaries.Any()) return null;

            var emails = notExistingContactSummaries.Select(c => c.Email).ToList();
            var domains = emails.Select(Domain).ToList();
            var emailsString = string.Join(",", emails.Select(c => $"'{c}'"));
            var domainsString = string.Join(",", domains.Select(c => $"'{c.GetDeterministicGuid()}'"));

            var hqlQuery =
                session.CreateQuery(
                    "select contractor " +
                    "FROM Contractor contractor " +
                    "LEFT JOIN contractor.Email e " +
                    "LEFT JOIN contractor.Domains d " +
                    "where " +
                    $"e.EmailString in ({emailsString}) OR " +
                    $"d.Uid in ({domainsString})");
            hqlQuery.SetMaxResults(notExistingContactSummaries.Count + 10);
            return hqlQuery.List<IContractorExt>();
        }

        private static IEnumerable<IContact> GetContacts(ISession session, string emailsString)
        {
            var hqlQuery =
                session.CreateQuery(
                    "select contact FROM Contact contact " +
                    "LEFT JOIN contact.Email e " +
                    $"where e.EmailString in ({emailsString})");
            hqlQuery.SetMaxResults(100);
            return hqlQuery.List<IContact>();
        }
    }
}