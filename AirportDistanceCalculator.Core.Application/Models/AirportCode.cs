using System.ComponentModel.DataAnnotations;

namespace AirportDistanceCalculator.Core.Application.Models
{
    public record AirportCode
    {
        public string Value { get; set; }
    }
}
