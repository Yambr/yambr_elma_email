using System;
using EleWise.ELMA.Model.Managers;
using EleWise.ELMA.Services;
using Yambr.ELMA.Email.Models;

namespace Yambr.ELMA.Email.Managers
{
    public class EmailMessageManager : EntityManager<IEmailMessage, long>
    {
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

        private string GetName(IEmailMessage emailMessage)
        {
            return $"{emailMessage.DateUtc:f} {emailMessage.SubjectWithoutTags}";
        }
    }
}