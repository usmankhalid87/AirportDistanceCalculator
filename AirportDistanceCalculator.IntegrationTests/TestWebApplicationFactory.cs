using AirportCalculator.Presentation.WebApi;
using AirportDistanceCalculator.Core.Application.Models;
using AirportDistanceCalculator.Core.Application.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;

namespace AirportDistanceCalculator.IntegrationTests
{
    public class TestWebApplicationFactory : WebApplicationFactory<Startup>
    {
        //public Mock<IAirportService> AirportServiceMock { get; }
        public TestWebApplicationFactory()
        {
            //AirportServiceMock = new Mock<IAirportService>(MockBehavior.Strict);
            //AirportServiceMock
            //    .Setup(x => x.GetAirportAsync(It.IsAny<AirportCode>()))
            //    .Returns(Result.SuccessData(new Airport()));
        }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {

        }
    }
}
