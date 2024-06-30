namespace AirportDistanceCalculator.Core.Application.Models
{
    public class Airport
    {
        public string Iata { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string City_iata { get; set; }
        public string Icao { get; set; }
        public string Country { get; set; }
        public int Rating { get; set; }
        public int Hubs { get; set; }
        public string Timezone_Region_Name { get; set; }
        public string Country_Iata { get; set; }
        public string Type { get; set; }
        public Location Location { get; set; }
    }
}