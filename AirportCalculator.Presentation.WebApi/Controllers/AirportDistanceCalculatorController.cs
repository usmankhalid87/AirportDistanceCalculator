using AirportDistanceCalculator.Core.Application.Features.AirportDistance.Commands;
using AirportDistanceCalculator.Core.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirportCalculator.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportDistanceCalculatorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AirportDistanceCalculatorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Calculate and get distance in miles between two airports by their codes
        /// </summary>
        /// <param name="originalAirportCode">original airport IATA code</param>
        /// <param name="destinationAirportCode">destination airport IATA code</param>
        /// <returns>Distance in miles</returns>
        [HttpGet("airports-distance/{originAirportCode}/{destinationAirportCode}")]
        [ProducesResponseType(typeof(AirportsDistance), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AirportsDistance>> CalculateAirportsDistance(string originAirportCode, string destinationAirportCode)
        {
            return Ok(await _mediator.Send(new CalculateAirportsDistanceCommand
            {
                OriginAirportCode = originAirportCode,
                DestinationAirportCode = destinationAirportCode
            }));
        }
    }
}
