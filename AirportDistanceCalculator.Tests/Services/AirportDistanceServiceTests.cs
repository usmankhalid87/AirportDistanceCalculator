using AirportDistanceCalculator.Core.Application.Models;
using AirportDistanceCalculator.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace AirportDistanceCalculator.Tests.Services
{
    public class AirportDistanceServiceTests
    {
        private readonly AirportDistanceService _airportDistanceService;
        public AirportDistanceServiceTests()
        {
            _airportDistanceService = new AirportDistanceService();
        }

        [Fact]
        public void GetDistance_ValidRequest_ReturnsDistanceResponse()
        {
            // Arrange
            var originAirport = new Airport
            {
                Location = new Location { Lon = 55.352916, Lat = 25.248664 }
            };

            var destinationAirport = new Airport
            {
                Location = new Location { Lon = 54.645974, Lat = 24.426912 }
            };

            // Act
            var distance = _airportDistanceService.GetDistance(originAirport.Location, destinationAirport.Location);

            // Assert
            Assert.True(distance > 0);
            Assert.True(distance == 72.03126262893694);
        }
    }
}
