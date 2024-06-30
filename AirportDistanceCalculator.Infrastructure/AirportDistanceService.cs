using AirportDistanceCalculator.Core.Application;
using AirportDistanceCalculator.Core.Application.Models;
using AirportDistanceCalculator.Core.Application.Services;

namespace AirportDistanceCalculator.Infrastructure
{
    public class AirportDistanceService : IAirportDistanceService
    {
        public double GetDistance(Location originAirportLocation, Location destinationAirportLocation)
        {
            var R = GlobalConstants.EarthRadius;
            var lat1 = originAirportLocation.Lat;
            var lat2 = destinationAirportLocation.Lat;
            var lon1 = originAirportLocation.Lon;
            var lon2 = destinationAirportLocation.Lon;

            var fi1 = lat1 * Math.PI / 180;
            var fi2 = lat2 * Math.PI / 180;
            var deltaFi = (lat2 - lat1) * Math.PI / 180;
            var deltaLambda = (lon2 - lon1) * Math.PI / 180;

            var a = Math.Sin(deltaFi / 2) * Math.Sin(deltaFi / 2) +
                    Math.Cos(fi1) * Math.Cos(fi2) *
                    Math.Sin(deltaLambda / 2) * Math.Sin(deltaLambda / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            // result distance in metres
            var d = R * c;
            var result = d * GlobalConstants.MilesInMeter;
            return result;
        }
    }
}
