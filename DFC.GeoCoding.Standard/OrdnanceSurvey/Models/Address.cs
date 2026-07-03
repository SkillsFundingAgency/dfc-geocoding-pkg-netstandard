using Newtonsoft.Json;

namespace DFC.GeoCoding.Standard.OrdnanceSurvey.Models
{
    public class Address
    {
        [JsonProperty("header")]
        public Header Header { get; set; }

        [JsonProperty("results")]
        public Result[] Results { get; set; }
    }
}
