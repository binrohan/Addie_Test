using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Addie.Helpers
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
         public bool IsError { get; set; } = false;

        public ApiResponse(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
            IsError = DetectError(statusCode);
        }

        private string? GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                200 => "Success",
                201 => "Post Success",
                204 => "Update Success",
                205 => "Patch Success",
                400 => "Bad Request",
                401 => "Unauthorize",
                404 => "Not Found",
                405 => "Not Allowed",
                406 => "Not Accepted",
                418 => "Failed to Save",
                500 => "Internal Server Error",
                _ => null
            };
        }

        private bool DetectError(int DetectError)
        {
            return DetectError > 299 || 200 > DetectError;
        }
    }
    public class ApiResponse<T> : ApiResponse where T : class
    {
        public ApiResponse(int statusCode, T data, string? message = null) :base(statusCode, message)
        {
            Data = data;
        }

        public T? Data { get; set; }
    }
}