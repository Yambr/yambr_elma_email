using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Yambr.ELMA.Email.Common.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EmailLoadingStatus
    {
        Disabled = 0,
        Active = 1,
        Error = 2
    }
}