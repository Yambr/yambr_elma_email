using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EleWise.ELMA.Cache;
using EleWise.ELMA.Extensions;
using EleWise.ELMA.Logging;
using EleWise.ELMA.Model.Managers;
using EleWise.ELMA.Runtime.NH;
using EleWise.ELMA.Services;
using Yambr.ELMA.Email.DTO.Models;
using Yambr.ELMA.Email.Models;

namespace Yambr.ELMA.Email.Managers
{
    public class EmailMessageManager : EntityManager<IEmailMessage, long>
    {
        private readonly ISessionProvider _sessionProvider;
        private readonly ICacheService _cacheService;
        private const string EmailMessageRegion = "EmailMessage";
        private new static readonly ILogger Logger = EmailLogger.Logger;

        public EmailMessageManager(
            ISessionProvider sessionProvider, ICacheService cacheService)
        {
            _sessionProvider = sessionProvider;
            _cacheService = cacheService;
        }
        private static EmailMessageManager _manager;

        public new static EmailMessageManager Instance => _manager ?? (_manager = Locator.GetServiceNotNull<EmailMessageManager>());

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
            var contractorStatKey = $"{id}";
            var stats = _cacheService.Get<List<EmailMonthStatDto>>(contractorStatKey, EmailMessageRegion);
            if (stats != null) return stats;

            var session = _sessionProvider.GetSession("");
            var hqlQuery =
                session.CreateQuery("select year(em.DateUtc) as Year, " +
                                    "month(em.DateUtc) as Month, " +
                                    "COUNT(em.Id) as CountInMonth " +
                                    "from  EmailMessage as em\r\n" +
                                    "left join em.To emto\r\n" +
                                    "left join em.From emfrom\r\n" +
                                    "where  \r\n" +
                                    "emto.Id in (select empcto.Id from EmailMessageParticipantContact as empcto \r\n" +
                                    $"left join  empcto.Contact contact left join contact.Contractor contractor where contractor.Id = {id})\r\n" +
                                    "OR \r\n" +
                                    "emfrom.Id in (select empcto.Id from EmailMessageParticipantContact as empcto \r\n" +
                                    $"left join  empcto.Contact contact left join contact.Contractor contractor where contractor.Id = {id})\r\n" +
                                    "GROUP BY year(em.DateUtc), month(em.DateUtc) " +
                                    "ORDER BY year(em.DateUtc), month(em.DateUtc)");
            stats = 
                hqlQuery
                    .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(EmailMonthStatDto)))
                    .List<EmailMonthStatDto>().ToList();

            var cacheDuration = TimeSpan.FromMinutes(15);
            _cacheService.Insert(contractorStatKey, stats, EmailMessageRegion, cacheDuration);

            return stats;
        }
    }
}