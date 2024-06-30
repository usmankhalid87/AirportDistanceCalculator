using AirportDistanceCalculator.Core.Application.Models;

namespace AirportCalculator.Core.Services
{
    public interface IAirportDistanceService
    {
        Task<double> GetAirportDistanceAsync(Location originAirportLocation, Location destinationAirportLocation);
    }
}
