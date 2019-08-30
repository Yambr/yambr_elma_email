using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yambr.ELMA.Email.Common.Models;

namespace Yambr.ELMA.Email.Components
{
    class EmailMessageHandler : AbstractRabbitMessageHandler<EmailMessage, bool>
    {
        public override string[] Model => new[] { "EmailMessage" };
        public override bool Run(EmailMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
