using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using EleWise.ELMA.Cache;
using EleWise.ELMA.Extensions;
using EleWise.ELMA.Model.Managers;
using EleWise.ELMA.Model.Services;
using EleWise.ELMA.Runtime.Db.Migrator.Framework;
using EleWise.ELMA.Runtime.NH;
using EleWise.ELMA.Security;
using EleWise.ELMA.Services;
using Yambr.ELMA.Email.Models;

namespace Yambr.ELMA.Email.Managers
{
    public class PublicDomainManager : EntityManager<IPublicDomain, long>
    {
        private static PublicDomainManager _manager;

        private readonly ICacheService _cacheService;
        private readonly ISessionProvider _sessionProvider;

        private const string EmailMessageRegion = "EmailMessage";
        private const string PublicDomainsKey = "PublicDomains";

        public PublicDomainManager(ICacheService cacheService, ISessionProvider sessionProvider)
        {
            _cacheService = cacheService;
            _sessionProvider = sessionProvider;
        }
        public new static PublicDomainManager Instance => _manager ?? (_manager = Locator.GetServiceNotNull<PublicDomainManager>());

        //TODO insert new publicdomains

        public IPublicDomain Load(string hash)
        {
            var guid = GetUid(hash);
            return LoadOrNull(guid);
        }

        private static Guid GetUid(string domain)
        {
            return domain.GetDeterministicGuid();
        }

        public override void Save(IPublicDomain obj)
        {
            obj.Uid = GetUid(obj.Name);
            base.Save(obj);
        }

        public ICollection<string> GetPublicDomains()
        {
            var publicDomains = _cacheService.Get<List<string>>(PublicDomainsKey, EmailMessageRegion);
            if (publicDomains == null)
            {
                publicDomains = Projection<string>(nameof(IPublicDomain.Name)).ToList();
                _cacheService.Insert(PublicDomainsKey, publicDomains, EmailMessageRegion, TimeSpan.FromHours(1));
            }

            return publicDomains;
        }

        internal void UpdateDomains(List<string> domains)
        {
            var uids = domains.Select(c => new { domain = c, uid = GetUid(c) }).ToList();
            var uidsString = string.Join(",", uids.Select(c => $"'{c.uid}'"));

            var session = _sessionProvider.GetSession("");

            var hqlQuery =
                session.CreateQuery(
                    "select publicdomain.Uid FROM PublicDomain publicdomain " +
                    $"where publicdomain.Uid in ({uidsString})");
            hqlQuery.SetMaxResults(domains.Count);
            var existingDomains = hqlQuery.List<Guid>();
            var newDomains = uids.Where(c => !existingDomains.Contains(c.uid));
            foreach (var newDomain in newDomains)
            {
                var publicDomain = InterfaceActivator.Create<IPublicDomain>();
                publicDomain.Name = newDomain.domain;
                publicDomain.Save();
            }
        }

        internal Exception UpdateDomains()
        {
            try
            {
                var securityService = Locator.GetService<ISecurityService>();
                securityService.RunByUser(EleWise.ELMA.Security.Managers.UserManager.Instance.Load(SecurityConstants.AdminUserUid), () =>
                {

                    using (var client = new WebClient())
                    {
                        var settings = Locator.GetServiceNotNull<YambrEmailSettingsModule>().Settings;
                        var text = client.DownloadString(new Uri(settings.PublicDomainUrl));
                        var domains = text.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                        UpdateDomains(domains);
                    }
                });
                return null;

            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}