using AirportDistanceCalculator.Core.Application.Models;

namespace AirportDistanceCalculator.Core.Application.Services
{
    public interface IAirportDistanceService
    {
        double GetDistance(Location originAirportLocation, Location destinationAirportLocation);
    }
}
