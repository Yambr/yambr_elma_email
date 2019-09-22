using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Yambr.ELMA.Email.DTO.Models
{
    [Serializable]
    public class EmailMonthStatDto
    {
        [JsonProperty("month")]
        public int Month { get; set; }
        [JsonProperty("year")]
        public int Year { get; set; }
        [JsonProperty("count")]
        public long CountInMonth { get; set; }
    }
}
