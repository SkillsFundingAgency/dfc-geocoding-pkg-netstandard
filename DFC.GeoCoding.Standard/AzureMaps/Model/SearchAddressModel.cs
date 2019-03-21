using System.Collections.Generic;

namespace DFC.GeoCoding.Standard.AzureMaps.Model
{
    public class SearchAddressModel
    {
        public Summary Summary { get; set; }
        public List<Result> Results { get; set; }
    }
}