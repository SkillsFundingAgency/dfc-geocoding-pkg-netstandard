using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DFC.GeoCoding.Standard.AzureMaps.Service;
using DFC.GeoCoding.Standard.OrdnanceSurvey.Models;
using DFC.GeoCoding.Standard.OrdnanceSurvey.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace DFC.GeoCoding.Standard.OrdnanceSurvey.Services
{
    public class OSService : IOSService
    {
        private readonly ILogger<OSService> _logger;
        private readonly IAzureMapService _azureMapService;
        private readonly HttpClient _httpClient;
        private readonly OSServiceOptions _options;

        public OSService(
            HttpClient httpClient,
            IOptions<OSServiceOptions> options,
            IAzureMapService azureMapService,
            ILogger<OSService> logger)
        {
            _logger = logger;
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
            _azureMapService = azureMapService ?? throw new ArgumentNullException(nameof(azureMapService));
        }

        public async Task<Position> GetPositionForPostcodeAsync(string postcode)
        {
            if (string.IsNullOrWhiteSpace(postcode))
            {
                _logger.LogInformation("PostCodeSearchService: postcode is empty, returning null");
                return null;
            }

            if (_options.UseOsApi)
            {
                _logger.LogInformation("PostCodeSearchService configured to use OS API for postcode: {Postcode}", postcode);

                var result = await FindAddresses(postcode);

                return result?.Results?
                    .Select(resultItem =>
                    {
                        var dpa = resultItem.Dpa;
                        double longitude = 0;
                        double latitude = 0;

                        if (dpa != null)
                        {
                            longitude = dpa.Longitude;
                            latitude = dpa.Latitude;
                        }

                        return new Position()
                        {
                            Longitude = longitude,
                            Latitude = latitude
                        };
                    })
                    .Where(x => x != null)
                    .GroupBy(x => new { x.Longitude, x.Latitude })
                    .Select(g => g.First())
                    .FirstOrDefault();
            }

            _logger.LogInformation("PostCodeSearchService configured to use Azure Maps for postcode: {Postcode}", postcode);

            var position = await _azureMapService.GetPositionForAddress(postcode);

            if (position == null)
            {
                return null;
            }

            return new Position()
            {
                Longitude = position.Lon,
                Latitude = position.Lat
            };
        }

        private async Task<Address> FindAddresses(string postcode)
        {
            var url = new Uri(string.Format(_options.ApiUrl, postcode));

            if (!_httpClient.DefaultRequestHeaders.Contains("key"))
            {
                _httpClient.DefaultRequestHeaders.Add("key", _options.ApiKey);
            }

            using (var response = await _httpClient.GetAsync(url))
            {
                if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return null;
                }

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Address>(content, JsonSettings.Default);
            }
        }
    }
}