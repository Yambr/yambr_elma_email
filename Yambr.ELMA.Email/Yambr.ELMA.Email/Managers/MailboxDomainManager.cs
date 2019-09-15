using System;
using EleWise.ELMA.Extensions;
using EleWise.ELMA.Model.Managers;
using EleWise.ELMA.Services;
using Yambr.ELMA.Email.Models;

namespace Yambr.ELMA.Email.Managers
{
    public class MailboxDomainManager : EntityManager<IMailboxDomain, long>
    {
        private static MailboxDomainManager _manager;

        public new static MailboxDomainManager Instance => _manager ?? (_manager = Locator.GetServiceNotNull<MailboxDomainManager>());

        public IMailboxDomain Load(string hash)
        {
            var guid = GetUid(hash);
            return LoadOrNull(guid);
        }

        private static Guid GetUid(string domain)
        {
            return domain.GetDeterministicGuid();
        }

        public override void Save(IMailboxDomain obj)
        {
            obj.Uid = GetUid(obj.Name);
            base.Save(obj);
        }
    }
}