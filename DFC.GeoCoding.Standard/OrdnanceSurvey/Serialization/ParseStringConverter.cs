using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DFC.GeoCoding.Standard.OrdnanceSurvey.Serialization
{
    public class ParseStringConverter : JsonConverter<long>
    {
        public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                throw new JsonException("Cannot unmarshal null to type long");
            }

            if (reader.TokenType == JsonTokenType.String)
            {
                var stringValue = reader.GetString();
                if (long.TryParse(stringValue, out var result))
                {
                    return result;
                }
                throw new JsonException($"Cannot unmarshal '{stringValue}' to type long");
            }

            if (reader.TokenType == JsonTokenType.Number)
            {
                return reader.GetInt64();
            }

            throw new JsonException($"Unexpected token {reader.TokenType} when parsing long");
        }

        public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}