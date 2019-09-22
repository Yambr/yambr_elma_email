using System.Collections.Generic;
using System.Linq;
using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.Model.Services;
using Yambr.ELMA.Email.Common.Models;
using Yambr.ELMA.Email.Enums;
using Yambr.ELMA.Email.Managers;
using Yambr.ELMA.Email.Models;
using System.Web;
using EleWise.ELMA.Logging;
using EleWise.ELMA.Security;
using EleWise.ELMA.Services;

namespace Yambr.ELMA.Email.Services.Impl
{
    [Service]
    public class EmailService : IEmailService
    {
        private static readonly ILogger Logger = EmailLogger.Logger;

        public IEmailMessage Save(EmailMessage emailMessage)
        {
            var message = EmailMessageManager.Instance.Load(emailMessage.Hash);
            if (message != null)
                return message;
            message = InterfaceActivator.Create<IEmailMessage>();
            var userMailboxs = GetOwners(emailMessage.Owners);
            message.Owners.AddAll(userMailboxs);
            message.DateUtc = emailMessage.DateUtc;
            message.Hash = emailMessage.Hash;
            message.MainHeader = ConvertHeader(emailMessage.MainHeader);
            message.CommonHeaders = ConvertHeaders(emailMessage.CommonHeaders);
            message.Body = ConvertBody(emailMessage.Body);
            message.IsBodyHtml = emailMessage.IsBodyHtml;
            message.Subject = emailMessage.Subject;
            message.SubjectWithoutTags = emailMessage.SubjectWithoutTags;
            message.Direction = (EmailDirection)(int)emailMessage.Direction;
            if (Logger.IsDebugEnabled())
            {
                Logger.Log(LogLevel.Debug, $"{message.DateUtc?.ToLocalTime():g} :{ message.Direction} : { message.Subject}");
            }
            FillParticipants(userMailboxs.FirstOrDefault(), emailMessage, message);
          
            message.Tags = ConvertTags(emailMessage.Tags);
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
            if (emailHeaders == null) return null;
            var headers = emailHeaders.Select(c => $"<li>{ConvertHeader(c.Text)}</li>");
            var list = string.Join("", headers);
            return new HtmlString($"<ul>{list}</ul>");

        }

        private static ICollection<IUserMailbox> GetOwners(ICollection<MailOwnerSummary> emailMessageOwners)
        {
            var emailList = emailMessageOwners.Select(c => c.Email).ToList();
            return UserMailboxManager.Instance.GetUserMailboxes(emailList);
        }

        private static string ConvertTags(IEnumerable<HashTag> emailMessageTags)
        {
            return
                emailMessageTags != null ?
                    string.Join(",", emailMessageTags.Select(c => $"{c.Name}")) :
                    null;
        }

        private static void FillParticipants(IUserMailbox userMailbox, IMessagePart emailMessage, IEmailMessage message)
        {
            var participants = EmailMessageParticipants(userMailbox, emailMessage);

            var toParticipants =
                participants
                    .Where(c => 
                        emailMessage.To.Any(e => e.Email == c.EmailString)).ToList();
            message.To.AddAll(toParticipants);

            var fromParticipants = 
                participants
                    .Where(c => 
                        emailMessage.From.Any(e => e.Email == c.EmailString)).ToList();

            message.From.AddAll(fromParticipants);
        }

        private static List<IEmailMessageParticipant> EmailMessageParticipants(IUserMailbox userMailbox, IMessagePart emailMessage)
        {
            var contactSummaries = emailMessage.From.ToList();
            contactSummaries.AddRange(emailMessage.To);
            var emailList = contactSummaries.Select(c => c.Email).ToList();

            var emailMessageParticipantManager = EmailMessageParticipantManager.Instance;
            var participants = emailMessageParticipantManager.GetParticipants(emailList).ToList();

            var notExistingParticipants =
                contactSummaries
                    .Where(c =>
                        participants.All(e => e.EmailString != c.Email)).ToList();

            if (notExistingParticipants.Any())
            {
                 var securityService =    Locator.GetServiceNotNull<ISecurityService>();
                 securityService.RunByUser(userMailbox.Owner, () =>
                 {
                     var newParticipants = emailMessageParticipantManager.CreateParticipants(notExistingParticipants);
                     participants.AddRange(newParticipants);
                 });
            }

            return participants;
        }
    }
}
