using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DFC.GeoCoding.Standard.AzureMaps.Model;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DFC.GeoCoding.Standard.AzureMaps.Service
{
    public class AzureMapService : IAzureMapService
    {
        private string _apiVersion;
        private string _azureMapUrl;
        private string _subscriptionKey;
        private string _countrySet;
        private IHttpClientFactory _httpClientFactory;
        private float confidenceScoreBenchmark = (float)0.9;
        
        public AzureMapService()
        {
            VerifyRequiredArguments();
        }

        public AzureMapService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
            
            VerifyRequiredArguments();
        }

        private void VerifyRequiredArguments()
        {
            _azureMapUrl = Environment.GetEnvironmentVariable("AzureMapURL");

            if (string.IsNullOrEmpty(_azureMapUrl))
                throw new ArgumentNullException("_azureMapUrl");

            _apiVersion = Environment.GetEnvironmentVariable("AzureMapApiVersion");

            if (string.IsNullOrEmpty(_apiVersion))
                throw new ArgumentNullException("_apiVersion");

            _subscriptionKey = Environment.GetEnvironmentVariable("AzureMapSubscriptionKey");

            if (string.IsNullOrEmpty(_subscriptionKey))
                throw new ArgumentNullException("_subscriptionKey");

            _countrySet = Environment.GetEnvironmentVariable("AzureCountrySet");
        }

        public async Task<Position> GetPositionForAddress(Uri address)
        {
            if (_httpClientFactory == null)
            {
                throw new  Exception ("Please use the correct Constructor: AzureMapService(IHttpClientFactory clientFactory)");
            }

            var client = _httpClientFactory.CreateClient();

            return await ProcessRequest(BuildSearchUri(address.ToString()), client);
        }

        public async Task<Position> GetPositionForAddress(string address)
        {
            using (var client = new HttpClient())
            {
                return await ProcessRequest(BuildSearchUri(address), client);
            }
        }

        private string BuildSearchUri(string address)
        {
            return $"{_azureMapUrl}/address/json?api-version={_apiVersion}&subscription-key={_subscriptionKey}&query={address}&countrySet={_countrySet}";
        }

        private async Task<Position> ProcessRequest(string requestUri, HttpClient client)
        {
            var request = await client.GetAsync(requestUri);
            if (request == null || !request.IsSuccessStatusCode)
            {
                return null;
            }

            var content = await request.Content.ReadAsStringAsync();

            if (content == null)
            {
                return null;
            }

            var searchAddressModel = JsonConvert.DeserializeObject<SearchAddressModel>(content);

            if (searchAddressModel?.Results == null || !searchAddressModel.Results.Any() || searchAddressModel.Results.FirstOrDefault()?.Position == null || searchAddressModel.Results.FirstOrDefault()?.Score < confidenceScoreBenchmark)
            {
                return null;
            }

            return searchAddressModel.Results.Select(x => x.Position).FirstOrDefault();
        }
    }
}