using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Yambr.ELMA.Email.Common.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ConnectionType
    {
        IMAP = 0,
        POP3 = 1,
        SMTP = 2
    }
}