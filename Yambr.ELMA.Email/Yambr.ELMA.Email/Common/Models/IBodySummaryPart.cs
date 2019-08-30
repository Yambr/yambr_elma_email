using System.Collections.Generic;

namespace Yambr.ELMA.Email.Common.Models
{
    public interface IBodySummaryPart
    {
        string MainHeader { get; set; }
        ICollection<HeaderSummary> CommonHeaders { get; set; }
    }
}