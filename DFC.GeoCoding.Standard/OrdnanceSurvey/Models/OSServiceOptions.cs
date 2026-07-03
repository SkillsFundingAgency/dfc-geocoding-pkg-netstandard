namespace DFC.GeoCoding.Standard.OrdnanceSurvey.Models
{
    public class OSServiceOptions
    {
        public bool UseOsApi { get; set; } = false;
        public string ApiUrl { get; set; }
        public string ApiKey { get; set; }
    }
}
