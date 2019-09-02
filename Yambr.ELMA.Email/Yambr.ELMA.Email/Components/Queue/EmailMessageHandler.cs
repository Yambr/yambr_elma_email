using EleWise.ELMA.ComponentModel;
using Yambr.ELMA.Email.Common.Models;
using Yambr.ELMA.Email.Models;
using Yambr.ELMA.Email.Services;

namespace Yambr.ELMA.Email.Components.Queue
{
    [Component]
    public class EmailMessageHandler : AbstractRabbitMessageHandler<EmailMessage, IEmailMessage>
    {
        private readonly IEmailService _emailService;

        public EmailMessageHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public override string[] Model => new[] { "EmailMessage" };
        public override IEmailMessage Run(EmailMessage message)
        {
            return _emailService.Save(message);
        }
    }
}

