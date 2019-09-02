using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yambr.ELMA.Email.Common.Models;
using Yambr.ELMA.Email.Models;

namespace Yambr.ELMA.Email.Services
{
    public interface IEmailService
    {
        IEmailMessage Save(EmailMessage emailMessage);
    }
}
