using System.Collections.Generic;

namespace Yambr.ELMA.Email.Common.Models
{
    public interface IAttachmentsPart
    {
        ICollection<AttachmentSummary> Attachments { get; set; }
    }
}