using System;
using Yambr.ELMA.Email.Common.Enums;

namespace Yambr.ELMA.Email.Common.Models
{
    public interface ILoadingState
    {
      
        DateTime LastStartTimeUtc { get; set; }
        EmailLoadingStatus Status { get; set; }
    }
}