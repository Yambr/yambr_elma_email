using System;
using EleWise.ELMA.Extensions;
using EleWise.ELMA.Model.Managers;
using EleWise.ELMA.Security.Models;
using EleWise.ELMA.Services;
using Yambr.ELMA.Email.Models;

namespace Yambr.ELMA.Email.Managers
{
    public class EmailMessageParticipantUserManager : EntityManager<IEmailMessageParticipantUser, long>
    {
        private static EmailMessageParticipantUserManager _manager;

        public new static EmailMessageParticipantUserManager Instance => _manager ?? (_manager = Locator.GetServiceNotNull<EmailMessageParticipantUserManager>());

        public IEmailMessageParticipantUser Load(string email)
        {
            var guid = GetUid(email);
            return LoadOrNull(guid);
        }

        public static Guid GetUid(string email)
        {
            return email.GetDeterministicGuid();
        }

        public override void Save(IEmailMessageParticipantUser obj)
        {
            obj.Uid = GetUid(obj.EmailString);
            obj.Name = GetName(obj);
            base.Save(obj);
        }

        private static string GetName(IEmailMessageParticipantUser emailMessageParticipantUser)
        {
            return $"{emailMessageParticipantUser.User.GetShortName()} ({emailMessageParticipantUser.EmailString})";
        }
    }
}