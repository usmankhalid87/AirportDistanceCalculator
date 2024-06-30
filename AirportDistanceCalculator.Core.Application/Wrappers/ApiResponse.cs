﻿namespace AirportDistanceCalculator.Core.Application.Wrappers
{
    public class ApiResponse<T>
    {
        public ApiResponse()
        {

        }

        //success response
        public ApiResponse(T data, string message = null)
        {
            Succecced = true;
            Message = message;
            Data = data;
        }

        //faild response
        public ApiResponse(string message)
        {
            Succecced = false;
            Message = message;
        }

        public bool Succecced { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }
}
