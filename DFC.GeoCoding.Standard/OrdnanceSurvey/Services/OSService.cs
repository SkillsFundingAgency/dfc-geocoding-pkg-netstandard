using DFC.GeoCoding.Standard.OrdnanceSurvey.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DFC.GeoCoding.Standard.OrdnanceSurvey.Services
{
    public class OSService : IOSService
    {
        private readonly ILogger<OSService> _logger;
        private readonly HttpClient _httpClient;
        private readonly OSServiceOptions _options;
        private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNameCaseInsensitive = true
        };

        public OSService(
            HttpClient httpClient,
            IOptions<OSServiceOptions> options,
            ILogger<OSService> logger)
        {
            _logger = logger;
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
        }

        public async Task<Position> GetPositionForPostcodeAsync(string postcode)
        {
            if (string.IsNullOrWhiteSpace(postcode))
            {
                _logger.LogInformation("OSService: postcode is empty, returning null");
                return null;
            }

            _logger.LogInformation("Retrieving longitude and latitude for postcode: {Postcode}", postcode);

            var result = await FindAddresses(postcode);

            return result?.Results?
                .Select(resultItem =>
                {
                    var dpa = resultItem.Dpa;

                    if (dpa == null)
                    {
                        _logger.LogInformation("Ordnance Survey returned no results for postcode: {Postcode}, returning empty position", postcode);

                        return new Position();
                    }

                    _logger.LogInformation("Returning position for postcode: {Postcode} with longitude: {Longitude} and latitude: {Latitude}", postcode, dpa.Longitude, dpa.Latitude);

                    return new Position()
                    {
                        Longitude = dpa.Longitude,
                        Latitude = dpa.Latitude
                    };
                })
                .Where(x => x != null)
                .GroupBy(x => new { x.Longitude, x.Latitude })
                .Select(g => g.First())
                .FirstOrDefault();
        }

        private async Task<Address> FindAddresses(string postcode)
        {
            var url = new Uri(string.Format(_options.ApiUrl, postcode));

            if (!_httpClient.DefaultRequestHeaders.Contains("key"))
            {
                _httpClient.DefaultRequestHeaders.Add("key", _options.ApiKey);
            }

            using var response = await _httpClient.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Address>(content, JsonOptions);
        }
    }
}