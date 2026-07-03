using DFC.GeoCoding.Standard.OrdnanceSurvey.Serialization;
using System.Text.Json.Serialization;

namespace DFC.GeoCoding.Standard.OrdnanceSurvey.Models
{
    public class Dpa
    {
        [JsonPropertyName("UPRN")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Uprn { get; set; }

        [JsonPropertyName("UDPRN")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Udprn { get; set; }

        [JsonPropertyName("ADDRESS")]
        public string Address { get; set; }

        [JsonPropertyName("BUILDING_NUMBER")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long BuildingNumber { get; set; }

        [JsonPropertyName("BUILDING_NAME")]
        public string BUILDING_NAME { get; set; }

        [JsonPropertyName("THOROUGHFARE_NAME")]
        public string ThoroughfareName { get; set; }

        [JsonPropertyName("POST_TOWN")]
        public string PostTown { get; set; }

        [JsonPropertyName("POSTCODE")]
        public string Postcode { get; set; }

        [JsonPropertyName("ORGANISATION_NAME")]
        public string ORGANISATION_NAME { get; set; }

        [JsonPropertyName("SUB_BUILDING_NAME")]
        public string SUB_BUILDING_NAME { get; set; }

        [JsonPropertyName("RPC")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Rpc { get; set; }

        [JsonPropertyName("X_COORDINATE")]
        public long XCoordinate { get; set; }

        [JsonPropertyName("Y_COORDINATE")]
        public long YCoordinate { get; set; }

        [JsonPropertyName("LNG")]
        public long Longitude { get; set; }

        [JsonPropertyName("LAT")]
        public long Latitude { get; set; }

        [JsonPropertyName("STATUS")]
        public string Status { get; set; }

        [JsonPropertyName("LOGICAL_STATUS_CODE")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long LogicalStatusCode { get; set; }

        [JsonPropertyName("CLASSIFICATION_CODE")]
        public string ClassificationCode { get; set; }

        [JsonPropertyName("CLASSIFICATION_CODE_DESCRIPTION")]
        public string ClassificationCodeDescription { get; set; }

        [JsonPropertyName("LOCAL_CUSTODIAN_CODE")]
        public long LocalCustodianCode { get; set; }

        [JsonPropertyName("LOCAL_CUSTODIAN_CODE_DESCRIPTION")]
        public string LocalCustodianCodeDescription { get; set; }

        [JsonPropertyName("COUNTRY_CODE")]
        public string CountryCode { get; set; }

        [JsonPropertyName("COUNTRY_CODE_DESCRIPTION")]
        public string CountryCodeDescription { get; set; }

        [JsonPropertyName("POSTAL_ADDRESS_CODE")]
        public string PostalAddressCode { get; set; }

        [JsonPropertyName("POSTAL_ADDRESS_CODE_DESCRIPTION")]
        public string PostalAddressCodeDescription { get; set; }

        [JsonPropertyName("BLPU_STATE_CODE")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long BlpuStateCode { get; set; }

        [JsonPropertyName("BLPU_STATE_CODE_DESCRIPTION")]
        public string BlpuStateCodeDescription { get; set; }

        [JsonPropertyName("TOPOGRAPHY_LAYER_TOID")]
        public string TopographyLayerToid { get; set; }

        [JsonPropertyName("WARD_CODE")]
        public string WardCode { get; set; }

        [JsonPropertyName("LAST_UPDATE_DATE")]
        public string LastUpdateDate { get; set; }

        [JsonPropertyName("ENTRY_DATE")]
        public string EntryDate { get; set; }

        [JsonPropertyName("BLPU_STATE_DATE")]
        public string BlpuStateDate { get; set; }

        [JsonPropertyName("LANGUAGE")]
        public string Language { get; set; }

        [JsonPropertyName("MATCH")]
        public long Match { get; set; }

        [JsonPropertyName("MATCH_DESCRIPTION")]
        public string MatchDescription { get; set; }

        [JsonPropertyName("DELIVERY_POINT_SUFFIX")]
        public string DeliveryPointSuffix { get; set; }
    }
}