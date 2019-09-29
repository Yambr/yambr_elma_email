using System.Web;
using Newtonsoft.Json;

namespace Yambr.ELMA.Email.DTO.Models
{
    public partial class EmailMessageDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("isBodyHtml")]
        public bool IsBodyHtml { get; set; }

        [JsonIgnore]
        public HtmlString Body { get; set; }

        [JsonProperty("body")]
        public string BodyHtmlString
        {
            get => Body?.ToHtmlString();
            set => Body = new HtmlString(value);
        }
    }
}
