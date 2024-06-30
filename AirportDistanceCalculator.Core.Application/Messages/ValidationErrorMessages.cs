namespace AirportDistanceCalculator.Core.Application.Messages
{
    public static class ValidationErrorMessages
    {
        public const string INVALID_AIRPORT_CODE = "Invalid IATA airport code : {PropertyValue}, Airport code can only contain 3 letters alphabets";
        public const string INVALID_AIRPORT_CODE_REQUIRED = "Invalid IATA airport code : {PropertyValue}, Airport code cannot be empty";
    }
}
