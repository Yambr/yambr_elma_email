using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Yambr.ELMA.Email.Common.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Direction
    {
        Incoming,
        Outcoming
    }
}