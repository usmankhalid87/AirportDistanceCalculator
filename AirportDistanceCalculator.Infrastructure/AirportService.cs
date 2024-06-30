using AirportDistanceCalculator.Core.Application.Models;
using AirportDistanceCalculator.Core.Application.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using AirportDistanceCalculator.Core.Application.Exceptions;

namespace AirportDistanceCalculator.Infrastructure
{
    public class AirportService : IAirportService
    {
        private readonly IConfiguration _configuration;
        private readonly string _endpoint;
        private readonly HttpClient _httpClient;
        public AirportService(IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            _configuration = configuration;
            _endpoint = _configuration["AirportEndPoint:AirportEndpointBaseUrl"];
            _httpClient = clientFactory.CreateClient("AirportDistanceCalculator"); ;
        }
        public async Task<Airport> GetAirportAsync(AirportCode airportCode)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_endpoint + airportCode.Value);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(content);
                return _ = jsonObject.ToObject<Airport>();
            }

            throw new ApiException($"Get airport information request by airport code: {airportCode.Value} has failed with result {(int)response.StatusCode}: {response.ReasonPhrase}");
        }
    }
}