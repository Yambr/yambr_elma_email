using System.Collections.Generic;
using System.Linq;
using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.Model.Services;
using EleWise.ELMA.Runtime.Db.Migrator.Framework;
using EleWise.ELMA.Runtime.NH;
using Yambr.ELMA.Email.Common.Models;
using Yambr.ELMA.Email.Enums;
using Yambr.ELMA.Email.Managers;
using Yambr.ELMA.Email.Models;
using System.Web;

namespace Yambr.ELMA.Email.Services.Impl
{
    [Service]
    public  class EmailService : IEmailService
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly ISessionProvider _sessionProvider;
        private readonly ITransformationProvider _transformationProvider;

        public EmailService(ISessionProvider sessionProvider, ITransformationProvider transformationProvider)
        {
            _sessionProvider = sessionProvider;
            _transformationProvider = transformationProvider;
        }

        public IEmailMessage Save(EmailMessage emailMessage)
        {
            var message = EmailMessageManager.Instance.Load(emailMessage.Hash);
            if (message != null)
                return message;
            message = InterfaceActivator.Create<IEmailMessage>();
            message.DateUtc = emailMessage.DateUtc;
            message.Hash = emailMessage.Hash;
            message.MainHeader = ConvertHeader(emailMessage.MainHeader);
            message.CommonHeaders = ConvertHeaders(emailMessage.CommonHeaders);
            message.Body = ConvertBody(emailMessage.Body);
            message.IsBodyHtml = emailMessage.IsBodyHtml;
            message.Subject = emailMessage.Subject;
            message.SubjectWithoutTags = emailMessage.SubjectWithoutTags;
            FillParticipants(emailMessage, message);
            message.Direction = (EmailDirection)(int)emailMessage.Direction;
            message.Tags = ConvertTags(emailMessage.Tags);
            message.Owners = GetOwners(emailMessage.Owners);
            message.Save();
            return message;
        }

        private static HtmlString ConvertHeader(string emailHeader)
        {
            return new HtmlString($"<i>{emailHeader}</i>");
        }

        private static HtmlString ConvertBody(string emailMessageBody)
        {
           return new HtmlString(emailMessageBody);
        }

        private static HtmlString ConvertHeaders(IEnumerable<HeaderSummary> emailHeaders)
        {
            var headers = emailHeaders.Select(c=>ConvertHeader(c.Text));
            var list = string.Join("", headers);
            return new HtmlString($"<ul>{list}</ul>");
        }

        private static IUserMailbox GetOwners(ICollection<MailOwnerSummary> emailMessageOwners)
        {
            //TODO
            return null;
        }

        private static string ConvertTags(IEnumerable<HashTag> emailMessageTags)
        {
            return 
                string.Join(",", emailMessageTags.Select(c => $"#{c.Name}"));
        }

        private static void FillParticipants(EmailMessage emailMessage, IEmailMessage message)
        {
            //TODO
          /*  message.To = emailMessage.To;
            message.From = emailMessage.From;*/
        }
    }
}
