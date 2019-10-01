﻿using EleWise.ELMA.ComponentModel;
using Yambr.ELMA.Email.Common.Enums;
using Yambr.ELMA.Email.Common.Models;
using Yambr.ELMA.Email.Managers;
using Yambr.ELMA.Email.Models;
using Yambr.ELMA.Email.Services;

namespace Yambr.ELMA.Email.Components.Queue
{
    [Component]
    public class MailBoxHandler : AbstractRabbitMessageHandler<MailBox, EmailLoadingStatus>
    {
        private readonly UserMailboxManager _userMailboxManager;

        public MailBoxHandler(UserMailboxManager userMailboxManager)
        {
            _userMailboxManager = userMailboxManager;
        }
        public override string[] Model => new[] { "Mailbox" };
        public override EmailLoadingStatus Run(MailBox mailBox)
        {
            _userMailboxManager.UpdateEvent(mailBox);
            return mailBox.Status;
        }
    }
}
