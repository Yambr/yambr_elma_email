using System;
using System.Linq;
using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.Model.Services;
using EleWise.ELMA.Services;
using Yambr.ELMA.Email.Common.Models;
using Yambr.ELMA.Email.Managers;
using IPhone = EleWise.ELMA.CRM.Models.IPhone;

namespace Yambr.ELMA.Email.Components.Queue
{
    [Component]
    public class ContactHandler : AbstractRabbitMessageHandler<Contact, EleWise.ELMA.CRM.Models.IContact>
    {
      
        public override string[] Model => new[] { "Contact" };
        public override EleWise.ELMA.CRM.Models.IContact Run(Contact contact)
        {
            var email = contact.Emails.FirstOrDefault()?.EmailString;
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("EmailString", $"{contact.Fio} пришел с пустым email");
            }

            var participant = EmailMessageParticipantContactManager.Instance.Load(email);
            var contactSummary = new ContactSummary(email, contact);
            var participantContact = participant?.Contact;
            if (participantContact == null)
            {
                var domain = EmailMessageParticipantManager.Domain(email);
                var mailboxDomain = MailboxDomainManager.Instance.Load(domain);
                var mailboxDomainContractor = mailboxDomain?.Contractor;
                if (mailboxDomainContractor == null)
                {
                    var settings = Locator.GetServiceNotNull<YambrEmailSettingsModule>().Settings;
                    if (settings.AutoCreateContractors)
                    {
                        mailboxDomainContractor = EmailMessageParticipantManager.CreateContractor(domain);
                    }
                }
                
                participantContact =
                        EmailMessageParticipantManager.CreateContact(
                            contactSummary,
                            mailboxDomainContractor);
                var messageParticipant = EmailMessageParticipantManager.CreateParticipant(contactSummary, participantContact);
                messageParticipant.Save();
            }

            UpdateByContact(participantContact, contact, email);
            
            return participantContact;
        }
        private static void UpdateByContact(EleWise.ELMA.CRM.Models.IContact contact, Contact newContact, string email)
        {
            if (IsBad(contact.Firstname) && 
                !IsBad(newContact.FirstName))
                contact.Firstname = newContact.FirstName;

            if (IsBad(contact.Middlename) && 
                !IsBad(newContact.MiddleName))
                contact.Middlename = newContact.MiddleName;

            if (IsBad(contact.Surname) && 
                !IsBad(newContact.LastName))
                contact.Surname = newContact.LastName;

            if (IsBad(contact.Position) && 
                !IsBad(newContact.Position))
                contact.Position = newContact.Position;

            if (string.IsNullOrWhiteSpace(contact.Site) && 
                !string.IsNullOrWhiteSpace(newContact.Site))
                contact.Site = newContact.Site;

            //TODO переназвать
            if (IsBad(contact.Department) && 
                !IsBad(newContact.Description))
                contact.Department = newContact.Description;

            if (newContact.Phones?.Any() ?? false)
            {
                var newPhones =
                    newContact.Phones?.Where(
                        p => contact.Phone.All(c => c.PhoneString != p.PhoneString)).ToList();
                foreach (var newPhone in newPhones)
                {
                    var phone = InterfaceActivator.Create<IPhone>();
                    phone.PhoneString = newPhone.PhoneString;
                    contact.Phone.Add(phone);
                }
            }
        }

        private static bool IsBad(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return true;
            if (name.Length < 2) return true;
            return !HasRussian(name);
        }
        private static bool HasRussian(string name)
        {
            return name != null &&
                   name.Any(c => (c >= 'А' && c <= 'я') || c == 'ё' || c == 'Ё');
        }

    }
}

