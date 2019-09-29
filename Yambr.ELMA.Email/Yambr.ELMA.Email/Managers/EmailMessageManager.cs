using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EleWise.ELMA;
using EleWise.ELMA.CRM.Managers;
using EleWise.ELMA.CRM.Models;
using EleWise.ELMA.Extensions;
using EleWise.ELMA.FullTextSearch.Exceptions;
using EleWise.ELMA.FullTextSearch.ExtensionPoints;
using EleWise.ELMA.FullTextSearch.Model;
using EleWise.ELMA.FullTextSearch.Services;
using EleWise.ELMA.Logging;
using EleWise.ELMA.Model.Common;
using EleWise.ELMA.Model.Entities;
using EleWise.ELMA.Model.Filters;
using EleWise.ELMA.Model.Managers;
using EleWise.ELMA.Model.Metadata;
using EleWise.ELMA.Model.Services;
using EleWise.ELMA.Runtime.NH;
using EleWise.ELMA.Security.Models;
using EleWise.ELMA.Services;
using Yambr.ELMA.Email.API.Models;
using Yambr.ELMA.Email.DTO.Models;
using Yambr.ELMA.Email.Models;

namespace Yambr.ELMA.Email.Managers
{
    public class EmailMessageManager : EntityManager<IEmailMessage, long>
    {
        private readonly ISessionProvider _sessionProvider;
        private const string EmailMessageRegion = "EmailMessage";
        private new static readonly ILogger Logger = EmailLogger.Logger;

        public EmailMessageManager(
            ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        private static EmailMessageManager _manager;

        public new static EmailMessageManager Instance =>
            _manager ?? (_manager = Locator.GetServiceNotNull<EmailMessageManager>());

        public IEmailMessage Load(string hash)
        {
            var guid = GetUid(hash);
            return LoadOrNull(guid);
        }

        private static Guid GetUid(string hash)
        {
            return new Guid(hash);
        }

        public override void Save(IEmailMessage obj)
        {
            obj.Uid = GetUid(obj.Hash);
            obj.Name = GetName(obj);
            base.Save(obj);
        }

        private static string GetName(IEmailMessage emailMessage)
        {
            return $"{emailMessage.DateUtc:f} {emailMessage.SubjectWithoutTags}";
        }

        public IEnumerable<EmailMonthStatDto> MonthStatContractor(long id)
        {
            var session = _sessionProvider.GetSession("");
            var hqlQuery =
                session.CreateQuery("select year(em.DateUtc) as Year, " +
                                    "month(em.DateUtc) as Month, " +
                                    "COUNT(em.Id) as CountInMonth " +
                                    "from  EmailMessage as em\r\n" +
                                    "left join em.To emto\r\n" +
                                    "left join em.From emfrom\r\n" +
                                    "where  \r\n" +
                                    "em.IsDeleted <> 1 AND " +
                                    "emto.Id in (select empcto.Id from EmailMessageParticipantContact as empcto \r\n" +
                                    $"left join  empcto.Contact contact left join contact.Contractor contractor where contractor.Id = {id})\r\n" +
                                    "OR \r\n" +
                                    "emfrom.Id in (select empcto.Id from EmailMessageParticipantContact as empcto \r\n" +
                                    $"left join  empcto.Contact contact left join contact.Contractor contractor where contractor.Id = {id})\r\n" +
                                    "GROUP BY year(em.DateUtc), month(em.DateUtc) " +
                                    "ORDER BY year(em.DateUtc), month(em.DateUtc)");
            return
                hqlQuery
                    .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(EmailMonthStatDto)))
                    .List<EmailMonthStatDto>().ToList();
        }

        public EmailMessageDto LoadEmail(long id)
        {
            var session = _sessionProvider.GetSession("");
            var hqlQuery =
                session.CreateQuery(
                    "select em.Id as Id, em.IsBodyHtml as IsBodyHtml, em.Body as Body " +
                    "from  EmailMessage as em " +
                    "where em.Id = :id");
            hqlQuery.SetParameter("id", id);
            hqlQuery.SetMaxResults(1);
            return hqlQuery
                .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(EmailMessageDto)))
                .List<EmailMessageDto>().ToList().FirstOrDefault();
        }

        public EmailMessagesPage Contractor(long id, string searchString, int skip, int size)
        {
            if (size > 1000)
            {
                size = 1000;
            }

            if (size > 1000)
            {
                size = 1000;
            }

            var session = _sessionProvider.GetSession("");
            var count = ContractorCount(id, searchString);
            if (skip < count)
            {
                var hqlQuery =
                    session.CreateQuery(
                        "select em " +
                        "from  EmailMessage as em " +
                        "left join em.To emto " +
                        "left join em.From emfrom " +
                        "where " +
                        "em.IsDeleted <> 1 AND " +
                        "(em.Subject LIKE :searchString OR " +
                        "em.Body LIKE :searchString ) AND" +
                        "(emto.Id in (select empcto.Id from EmailMessageParticipantContact as empcto  left join  empcto.Contact contact left join contact.Contractor contractor where contractor.Id = :id) OR  " +
                        "emfrom.Id in (select empcto.Id from EmailMessageParticipantContact as empcto  left join  empcto.Contact contact left join contact.Contractor contractor where contractor.Id = :id)) " +
                        "ORDER BY em.DateUtc DESC");
                hqlQuery.SetParameter("id", id);
                hqlQuery.SetParameter("searchString", $"%{searchString}%");
                hqlQuery.SetFirstResult(skip);
                hqlQuery.SetMaxResults(size);
                var emailMessages = hqlQuery.List<IEmailMessage>();


                return new EmailMessagesPage()
                {
                    Messages = emailMessages.Select(Simplify).ToArray(),
                    Size = size,
                    Skip = skip,
                    Count = count
                };
            }
            else
            {

                return new EmailMessagesPage()
                {
                    Skip = skip,
                    Size = size,
                    Count = count,
                    Messages = new Message[0]
                };
            }
        }

        public EmailMessagesPage Contractor(long id, DateTime @from, DateTime to, int skip, int size)
        {
            if (size > 1000)
            {
                size = 1000;
            }

            var session = _sessionProvider.GetSession("");
            var count = ContractorCount(id, from, to);
            if (skip < count)
            {
                var hqlQuery =
                    session.CreateQuery(
                        "select em " +
                        "from  EmailMessage as em " +
                        "left join em.To emto " +
                        "left join em.From emfrom " +
                        "where " +
                        "em.IsDeleted <> 1 AND " +
                        "em.DateUtc >= :fromDate AND " +
                        "em.DateUtc < :toDate AND " +
                        "(emto.Id in (select empcto.Id from EmailMessageParticipantContact as empcto  left join  empcto.Contact contact left join contact.Contractor contractor where contractor.Id = :id) OR  " +
                        "emfrom.Id in (select empcto.Id from EmailMessageParticipantContact as empcto  left join  empcto.Contact contact left join contact.Contractor contractor where contractor.Id = :id)) " +
                        "ORDER BY em.DateUtc DESC");
                hqlQuery.SetParameter("id", id);
                hqlQuery.SetParameter("fromDate", @from);
                hqlQuery.SetParameter("toDate", to);
                hqlQuery.SetFirstResult(skip);
                hqlQuery.SetMaxResults(size);
                var emailMessages = hqlQuery.List<IEmailMessage>();


                return new EmailMessagesPage()
                {
                    Messages = emailMessages.Select(Simplify).ToArray(),
                    From = @from,
                    To = to,
                    Size = size,
                    Skip = skip,
                    Count = count
                };
            }
            else
            {

                return new EmailMessagesPage()
                {
                    From = @from,
                    Skip = skip,
                    To = to,
                    Size = size,
                    Count = count,
                    Messages = new Message[0]
                };
            }
        }

        private static Message Simplify(IEmailMessage emailMessage)
        {
            return new Message()
            {
                Id = emailMessage.Id,
                From = emailMessage.From.Select(Simplify).ToArray(),
                To = emailMessage.To.Select(Simplify).ToArray(),
                Date = emailMessage.DateUtc,
                Direction = $"{emailMessage.Direction}",
                MainHeader = emailMessage.MainHeader.ToString(),
                Owners = emailMessage.Owners.Select(Simplify).ToArray(),
                Subject = emailMessage.Subject,
                SubjectWithoutTags = emailMessage.SubjectWithoutTags
            };
        }

        private static Participant Simplify(IEmailMessageParticipant participant)
        {
            var simplify = new Participant()
            {
                Name = participant.Name,
                Email = participant.EmailString

            };
            if (participant is IEmailMessageParticipantContact)
            {
                simplify.Contact = ((IEmailMessageParticipantContact)participant).Contact.Id;
            }
            if (participant is IEmailMessageParticipantUser)
            {
                simplify.Contact = ((IEmailMessageParticipantUser)participant).User.Id;
            }

            return simplify;
        }

        private static Participant Simplify(IUserMailbox participant)
        {
            return new Participant()
            {
                Name = participant.Owner.GetShortName(),
                Email = participant.EmailLogin,
                User = participant.Owner.Id

            };
        }

        private long ContractorCount(long id, string searchString)
        {
            var session = _sessionProvider.GetSession("");
            var hqlQuery =
                session.CreateQuery(
                    "select COUNT(em.Id) " +
                    "from  EmailMessage as em " +
                    "left join em.To emto " +
                    "left join em.From emfrom " +
                    "where " +
                    "(em.Subject LIKE :searchString OR " +
                    "em.Body LIKE :searchString ) AND" +
                    "(emto.Id in (select empcto.Id from EmailMessageParticipantContact as empcto  left join  empcto.Contact contact left join contact.Contractor contractor where contractor.Id = :id) OR  " +
                    "emfrom.Id in (select empcto.Id from EmailMessageParticipantContact as empcto  left join  empcto.Contact contact left join contact.Contractor contractor where contractor.Id = :id))");
            hqlQuery.SetParameter("id", id);
            hqlQuery.SetParameter("searchString", $"%{searchString}%");
            return hqlQuery.List<long>().FirstOrDefault();
        }

        private long ContractorCount(long id, DateTime @from, DateTime to)
        {
            var session = _sessionProvider.GetSession("");
            var hqlQuery =
                session.CreateQuery(
                    "select COUNT(em.Id) " +
                    "from  EmailMessage as em " +
                    "left join em.To emto " +
                    "left join em.From emfrom " +
                    "where " +
                    "em.DateUtc >= :fromDate AND " +
                    "em.DateUtc < :toDate AND " +
                    "(emto.Id in (select empcto.Id from EmailMessageParticipantContact as empcto  left join  empcto.Contact contact left join contact.Contractor contractor where contractor.Id = :id) OR  " +
                    "emfrom.Id in (select empcto.Id from EmailMessageParticipantContact as empcto  left join  empcto.Contact contact left join contact.Contractor contractor where contractor.Id = :id))");
            hqlQuery.SetParameter("id", id);
            hqlQuery.SetParameter("fromDate", @from);
            hqlQuery.SetParameter("toDate", to);
            return hqlQuery.List<long>().FirstOrDefault();
        }


    }
}