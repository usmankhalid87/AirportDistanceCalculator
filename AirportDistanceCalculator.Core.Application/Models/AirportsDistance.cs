namespace AirportDistanceCalculator.Core.Application.Models
{
    public record AirportsDistance
    {
        public AirportsDistance(double value)
        {
            this.Value = value;
        }
        public double? Value { get; set; }
    }
}