using System.Collections.Generic;

namespace Yambr.ELMA.Email.Common.Models
{
    public interface ITagsPart
    {
        ICollection<HashTag> Tags { get; set; }
    }
}