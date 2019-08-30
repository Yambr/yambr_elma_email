using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Yambr.ELMA.Email.Common.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UserStatus
    {
        Pending = 0,
        Active = 1
    }
}