using DFC.GeoCoding.Standard.OrdnanceSurvey.Serialization;
using System;
using System.Text.Json.Serialization;

namespace DFC.GeoCoding.Standard.OrdnanceSurvey.Models
{
    public class Header
    {
        [JsonPropertyName("uri")]
        public Uri Uri { get; set; }

        [JsonPropertyName("query")]
        public string Query { get; set; }

        [JsonPropertyName("offset")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Offset { get; set; }

        [JsonPropertyName("totalresults")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Totalresults { get; set; }

        [JsonPropertyName("format")]
        public string Format { get; set; }

        [JsonPropertyName("dataset")]
        public string Dataset { get; set; }

        [JsonPropertyName("lr")]
        public string Lr { get; set; }

        [JsonPropertyName("maxresults")]
        public long Maxresults { get; set; }
    }
}