using AirportDistanceCalculator.Core.Application.Features.AirportDistance.Commands;
using AirportDistanceCalculator.Core.Application.Models;
using AirportDistanceCalculator.Core.Application.Services;
using AirportDistanceCalculator.Core.Application.Wrappers;
using MediatR;

namespace AirportDistanceCalculator.Core.Application.Features.AirportDistance.Handlers
{
    public class CalculateAirportDistanceCommandHandler : IRequestHandler<CalculateAirportsDistanceCommand, ApiResponse<AirportsDistance>>
    {
        private readonly IAirportService _airportService;
        private readonly IAirportDistanceService _airportDistanceService;
        public CalculateAirportDistanceCommandHandler(IAirportService airportService, IAirportDistanceService airportDistanceService)
        {
            _airportService = airportService;
            _airportDistanceService = airportDistanceService;
        }
        public async Task<ApiResponse<AirportsDistance>> Handle(CalculateAirportsDistanceCommand request, CancellationToken cancellationToken)
        {
            var originAirportTask = _airportService.GetAirportAsync(new AirportCode() { Value = request.OriginAirportCode });
            var destinationAirportTask = _airportService.GetAirportAsync(new AirportCode() { Value = request.DestinationAirportCode });

            await Task.WhenAll(originAirportTask, destinationAirportTask);

            var distanceInMiles = _airportDistanceService.GetDistance(originAirportTask.Result.Location, destinationAirportTask.Result.Location);
            return new ApiResponse<AirportsDistance>(new AirportsDistance(distanceInMiles));
        }
    }
}