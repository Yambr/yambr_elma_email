using System;
using EleWise.ELMA.Extensions;
using EleWise.ELMA.Model.Managers;
using EleWise.ELMA.Services;
using Yambr.ELMA.Email.Models;

namespace Yambr.ELMA.Email.Managers
{
    public class EmailMessageParticipantContactManager : EntityManager<IEmailMessageParticipantContact, long>
    {
        private static EmailMessageParticipantContactManager _manager;

        public new static EmailMessageParticipantContactManager Instance => _manager ?? (_manager = Locator.GetServiceNotNull<EmailMessageParticipantContactManager>());

        public IEmailMessageParticipantContact Load(string email)
        {
            var guid = GetUid(email);
            return LoadOrNull(guid);
        }

        public static Guid GetUid(string email)
        {
            return email.GetDeterministicGuid();
        }

        public override void Save(IEmailMessageParticipantContact obj)
        {
            obj.Uid = GetUid(obj.EmailString);
            obj.Name = GetName(obj);
            base.Save(obj);
        }

        private static string GetName(IEmailMessageParticipantContact emailMessageParticipantContact)
        {
            return $"{emailMessageParticipantContact.Contact} ({emailMessageParticipantContact.EmailString})";
        }
    }
}