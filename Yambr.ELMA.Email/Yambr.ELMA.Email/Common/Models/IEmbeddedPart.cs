using System.Collections.Generic;

namespace Yambr.ELMA.Email.Common.Models
{
    public interface IEmbeddedPart
    {
        ICollection<EmbeddedSummary> Embedded { get; set; }
    }
}