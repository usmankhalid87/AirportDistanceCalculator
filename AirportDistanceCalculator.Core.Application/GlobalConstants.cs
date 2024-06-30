namespace AirportDistanceCalculator.Core.Application
{
    public static class GlobalConstants
    {
        public const string AlphaBetsRegexPattern = @"^[A-Za-z]{3}$";
        public const double EarthRadius = 6371e3;
        public const double MilesInMeter = 0.0006213712;
        public const int NumberOfRetries = 3;
    }
}
