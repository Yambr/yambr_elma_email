using EleWise.ELMA.ComponentModel;
using Yambr.ELMA.Email.Common.Enums;
using Yambr.ELMA.Email.Common.Models;
using Yambr.ELMA.Email.Managers;

namespace Yambr.ELMA.Email.Components.Queue
{
    [Component]
    public class MailBoxHandler : AbstractRabbitMessageHandler<MailBox, EmailLoadingStatus>
    {
        public override string[] Model => new[] { "Mailbox" };
        public override EmailLoadingStatus Run(MailBox mailBox)
        {
            UserMailboxManager.Instance.UpdateEvent(mailBox);
            return mailBox.Status;
        }
    }
}

