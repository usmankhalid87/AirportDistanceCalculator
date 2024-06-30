using AirportDistanceCalculator.Core.Application.Models;

namespace AirportCalculator.Core.Services
{
    public interface IAirportInfoService
    {
        public Task<AirportInfo> GetAirportInformationAsync(AirportCode airportCode);
    }
}
