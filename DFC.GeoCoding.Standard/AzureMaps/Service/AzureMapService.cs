﻿using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DFC.GeoCoding.Standard.AzureMaps.Model;
using Newtonsoft.Json;

namespace DFC.GeoCoding.Standard.AzureMaps.Service
{
    public class AzureMapService : IAzureMapService
    {
        private readonly string _apiVersion;
        private readonly string _azureMapUrl;
        private readonly string _subscriptionKey;
        private readonly string _countrySet;

        public AzureMapService()
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

        public async Task<Position> GetPositionForAddress(string address)
        {
            var requestUri = string.Format("{0}/address/json?api-version={1}&subscription-key={2}&query={3}&countrySet={4}",
                _azureMapUrl, _apiVersion, _subscriptionKey, address, _countrySet);

            using (var client = new HttpClient())
            {
                var request = await client.GetAsync(requestUri);

                if (request == null)
                    return null;

                if (!request.IsSuccessStatusCode)
                    return null;

                var content = await request.Content.ReadAsStringAsync();

                if (content == null)
                    return null;

                var searchAddressModel = JsonConvert.DeserializeObject<SearchAddressModel>(content);

                if (searchAddressModel?.Results == null ||
                    !searchAddressModel.Results.Any() || 
                    searchAddressModel.Results.FirstOrDefault()?.Position == null)
                    return null;

                return searchAddressModel.Results.Select(x => x.Position).FirstOrDefault();

            }
        }


    }
}
