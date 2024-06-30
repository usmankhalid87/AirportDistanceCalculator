﻿using FluentValidation.Results;

namespace AirportDistanceCalculator.Core.Application.Exceptions
{
    public class ValidationErrorException : Exception
    {
        public ValidationErrorException() : base("One or more validations failure occured")
        {
            Errors = new List<string>();
        }

        public List<string> Errors { get; set; }
        public ValidationErrorException(List<ValidationFailure> failures) : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }
    }
}