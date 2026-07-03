using DFC.GeoCoding.Standard.OrdnanceSurvey.Serialization;
using Newtonsoft.Json;

namespace DFC.GeoCoding.Standard.OrdnanceSurvey.Models
{
    public class Dpa
    {
        
            [JsonProperty("UPRN")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long Uprn { get; set; }

            [JsonProperty("UDPRN")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long Udprn { get; set; }

            [JsonProperty("ADDRESS")]
            public string Address { get; set; }

            [JsonProperty("BUILDING_NUMBER", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(ParseStringConverter))]
            public long BuildingNumber { get; set; }

            [JsonProperty("BUILDING_NAME", NullValueHandling = NullValueHandling.Ignore)]
            public string BUILDING_NAME { get; set; }

            [JsonProperty("THOROUGHFARE_NAME", NullValueHandling = NullValueHandling.Ignore)]
            public string ThoroughfareName { get; set; }

            [JsonProperty("POST_TOWN")]
            public string PostTown { get; set; }

            [JsonProperty("POSTCODE")]
            public string Postcode { get; set; }

            [JsonProperty("ORGANISATION_NAME", NullValueHandling = NullValueHandling.Ignore)]
            public string ORGANISATION_NAME { get; set; }

            [JsonProperty("SUB_BUILDING_NAME", NullValueHandling = NullValueHandling.Ignore)]
            public string SUB_BUILDING_NAME { get; set; }

            [JsonProperty("RPC")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long Rpc { get; set; }

            [JsonProperty("X_COORDINATE")]
            public double XCoordinate { get; set; }

            [JsonProperty("Y_COORDINATE")]
            public double YCoordinate { get; set; }

            [JsonProperty("LNG")]
            public double Longitude { get; set; }

            [JsonProperty("LAT")]
            public double Latitude { get; set; }

            [JsonProperty("STATUS")]
            public string Status { get; set; }

            [JsonProperty("LOGICAL_STATUS_CODE")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long LogicalStatusCode { get; set; }

            [JsonProperty("CLASSIFICATION_CODE")]
            public string ClassificationCode { get; set; }

            [JsonProperty("CLASSIFICATION_CODE_DESCRIPTION")]
            public string ClassificationCodeDescription { get; set; }

            [JsonProperty("LOCAL_CUSTODIAN_CODE")]
            public long LocalCustodianCode { get; set; }

            [JsonProperty("LOCAL_CUSTODIAN_CODE_DESCRIPTION")]
            public string LocalCustodianCodeDescription { get; set; }

            [JsonProperty("COUNTRY_CODE")]
            public string CountryCode { get; set; }

            [JsonProperty("COUNTRY_CODE_DESCRIPTION")]
            public string CountryCodeDescription { get; set; }

            [JsonProperty("POSTAL_ADDRESS_CODE")]
            public string PostalAddressCode { get; set; }

            [JsonProperty("POSTAL_ADDRESS_CODE_DESCRIPTION")]
            public string PostalAddressCodeDescription { get; set; }

            [JsonProperty("BLPU_STATE_CODE")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long BlpuStateCode { get; set; }

            [JsonProperty("BLPU_STATE_CODE_DESCRIPTION")]
            public string BlpuStateCodeDescription { get; set; }

            [JsonProperty("TOPOGRAPHY_LAYER_TOID")]
            public string TopographyLayerToid { get; set; }

            [JsonProperty("WARD_CODE")]
            public string WardCode { get; set; }

            [JsonProperty("LAST_UPDATE_DATE")]
            public string LastUpdateDate { get; set; }

            [JsonProperty("ENTRY_DATE")]
            public string EntryDate { get; set; }

            [JsonProperty("BLPU_STATE_DATE")]
            public string BlpuStateDate { get; set; }

            [JsonProperty("LANGUAGE")]
            public string Language { get; set; }

            [JsonProperty("MATCH")]
            public double Match { get; set; }

            [JsonProperty("MATCH_DESCRIPTION")]
            public string MatchDescription { get; set; }

            [JsonProperty("DELIVERY_POINT_SUFFIX")]
            public string DeliveryPointSuffix { get; set; }
    }
}
