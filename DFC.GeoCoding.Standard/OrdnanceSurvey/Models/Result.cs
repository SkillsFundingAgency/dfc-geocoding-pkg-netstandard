using Newtonsoft.Json;

namespace DFC.GeoCoding.Standard.OrdnanceSurvey.Models
{
    public class Result
    {
        [JsonProperty("DPA", NullValueHandling = NullValueHandling.Ignore)]
        public Dpa Dpa { get; set; }
    }
}
