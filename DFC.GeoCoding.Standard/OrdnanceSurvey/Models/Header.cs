using DFC.GeoCoding.Standard.OrdnanceSurvey.Serialization;
using Newtonsoft.Json;
using System;

namespace DFC.GeoCoding.Standard.OrdnanceSurvey.Models
{
    public class Header
    {
        [JsonProperty("uri")]
        public Uri Uri { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }

        [JsonProperty("totalresults")]
        public long Totalresults { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("dataset")]
        public string Dataset { get; set; }

        [JsonProperty("lr")]
        public string Lr { get; set; }

        [JsonProperty("maxresults")]
        public long Maxresults { get; set; }

        [JsonProperty("epoch")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Epoch { get; set; }

        [JsonProperty("lastupdate")]
        public DateTimeOffset Lastupdate { get; set; }

        [JsonProperty("output_srs")]
        public string OutputSrs { get; set; }
    }
}
