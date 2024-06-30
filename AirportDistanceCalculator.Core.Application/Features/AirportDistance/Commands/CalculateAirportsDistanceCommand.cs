using AirportDistanceCalculator.Core.Application.Models;
using AirportDistanceCalculator.Core.Application.Wrappers;
using MediatR;

namespace AirportDistanceCalculator.Core.Application.Features.AirportDistance.Commands
{
    public class CalculateAirportsDistanceCommand : IRequest<ApiResponse<AirportsDistance>>
    {
        public string OriginAirportCode { get; set; }
        public string DestinationAirportCode { get; set; }
    }
}