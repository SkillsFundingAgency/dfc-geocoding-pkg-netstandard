using System.Text.Json.Serialization;

namespace DFC.GeoCoding.Standard.OrdnanceSurvey.Models
{
    public class Result
    {
        [JsonPropertyName("DPA")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dpa Dpa { get; set; }
    }
}