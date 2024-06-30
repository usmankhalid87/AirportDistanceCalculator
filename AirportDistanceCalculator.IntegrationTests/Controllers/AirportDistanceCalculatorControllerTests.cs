using AirportDistanceCalculator.Core.Application.Models;
using AirportDistanceCalculator.Core.Application.Wrappers;
using Newtonsoft.Json.Linq;
using System.Net;

namespace AirportDistanceCalculator.IntegrationTests.Controllers
{
    public class AirportDistanceCalculatorControllerTests : TestBase
    {
        [TestCase("LED", "_")]
        [TestCase("LED", "404")]
        [TestCase("LED", "AT")]
        [TestCase("LED", "INVALIDATA")]
        [TestCase("_", "LED")]
        [TestCase("404", "LED")]
        [TestCase("AT", "LED")]
        [TestCase("INVALIDATA", "LED")]
        public async Task Distance_InvalidIata_ShouldReturnError(string from, string to)
        {
            // act
            var httpResponse = await _client.GetAsync($"{baseUrl}/airports-distance/{from}/{to}");
            var error = await GetResponseAsync<ApiResponse<string>>(httpResponse);

            // assert
            Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(error, Is.Not.Null);
            Assert.That(error.Succecced, Is.False);
        }

        [TestCase("LED", "AMS")]
        public async Task Distance_ValidData_ShouldGetDataFromProvider(string from, string to)
        {
            // arrange
            const double expectedDistance = 1102.2148091856811;
            // act
            var response = await _client.GetAsync($"{baseUrl}/airports-distance/{from}/{to}");
            var apiResponse = await GetResponseAsync<ApiResponse<AirportsDistance>>(response);

            // assert
            Assert.That(response, Is.Not.Null);
            Assert.That(apiResponse, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(apiResponse.Succecced, Is.True);
            Assert.That(apiResponse.Data.Value, Is.EqualTo(expectedDistance));
        }

        private async Task<T> GetResponseAsync<T>(HttpResponseMessage httpResponseMessage)
        {
            try
            {
                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(content);
                return jsonObject.ToObject<T>();
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}
