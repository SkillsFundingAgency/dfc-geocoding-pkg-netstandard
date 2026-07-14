using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace DFC.GeoCoding.Standard.OrdnanceSurvey.Serialization
{
    public static class JsonSettings
    {
        public static readonly JsonSerializerSettings Default = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}