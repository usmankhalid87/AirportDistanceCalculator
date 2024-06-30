using AirportDistanceCalculator.Core.Application.Features.AirportDistance.Commands;
using AirportDistanceCalculator.Core.Application.Messages;
using FluentValidation;

namespace AirportDistanceCalculator.Core.Application.CustomValidations
{
    public class CalculateAirportDistanceCommandValidator : AbstractValidator<CalculateAirportsDistanceCommand>
    {
        public CalculateAirportDistanceCommandValidator()
        {
            RuleFor(x => x.OriginAirportCode)
              .NotEmpty().WithMessage(ValidationErrorMessages.INVALID_AIRPORT_CODE_REQUIRED)
              .Matches(GlobalConstants.AlphaBetsRegexPattern).WithMessage(ValidationErrorMessages.INVALID_AIRPORT_CODE);

            RuleFor(x => x.DestinationAirportCode)
                .NotEmpty().WithMessage(ValidationErrorMessages.INVALID_AIRPORT_CODE_REQUIRED)
                .Matches(GlobalConstants.AlphaBetsRegexPattern).WithMessage(ValidationErrorMessages.INVALID_AIRPORT_CODE);
        }
    }
}
