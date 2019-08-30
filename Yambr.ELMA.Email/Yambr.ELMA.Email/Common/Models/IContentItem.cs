using System;
using System.Collections.Generic;

namespace Yambr.ELMA.Email.Common.Models
{
    public interface IContentItem
    {
        DateTime DateUtc { get; set; }
        string Hash { get; set; }
        ICollection<MailOwnerSummary> Owners { get; set; }
    }
}