using AirportDistanceCalculator.Core.Application.Features.AirportDistance.Handlers;
using MediatR;
using Moq;

namespace AirportDistanceCalculator.Core.Tests.Commands
{
    public class CalculateAirportDistanceCommandHandlerTests
    {
        private CalculateAirportDistanceCommandHandler _handler;

        [SetUp]
        public void Setup()
        {

            _handler = new CalculateAirportDistanceCommandHandler(_mediatorMock.Object);
        }

        [Test]
        public async Task ExecuteAsync_ShouldCallCalculateDistanceCommand()
        {
            // arrange
            var from = new AirportDto { Iata = "LED", Location = new LocationDto() };
            var to = new AirportDto { Iata = "AMS", Location = new LocationDto() };
            var command = new CalculateDistanceBetweenAirportsCommand(from, to);

            // act
            var result = await _handler.ExecuteAsync(command);

            // assert
            Assert.That(result, Is.Not.Null);

            // verify
            _mediatorMock.Verify(
                x => x.ExecuteAsync(It.Is<IPipeline<double>>(r => r is CalculateDistanceBetweenLocationsCommand)),
                Times.Once);
        }
    }
}
