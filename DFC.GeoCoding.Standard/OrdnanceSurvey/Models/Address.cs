using System.Text.Json.Serialization;

namespace DFC.GeoCoding.Standard.OrdnanceSurvey.Models
{
    public class Address
    {
        [JsonPropertyName("header")]
        public Header Header { get; set; }

        [JsonPropertyName("results")]
        public Result[] Results { get; set; }
    }
}