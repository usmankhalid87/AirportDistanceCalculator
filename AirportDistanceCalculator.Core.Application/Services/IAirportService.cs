using AirportDistanceCalculator.Core.Application.Models;

namespace AirportDistanceCalculator.Core.Application.Services
{
    public interface IAirportService
    {
        Task<Airport> GetAirportAsync(AirportCode airportCode);
    }
}
