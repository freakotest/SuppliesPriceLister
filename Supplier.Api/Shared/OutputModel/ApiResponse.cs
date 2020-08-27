using Newtonsoft.Json;
using System.Net;

namespace Supplier.Api.Shared.OutputModel
{
    public class ApiResponse
    {
        public int StatusCode { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }

        public ApiException UnhandledException { get; set; }

        public ApiResponse(int statusCode, string message = null, ApiException unhandledException = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode((int)statusCode);
            UnhandledException = unhandledException;
        }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 400:
                    return "Bad Request";
                case 404:
                    return "Resource not found";
                case 500:
                    return "An unhandled error occurred";
                default:
                    return null;
            }
        }

    }

    public class ApiResponse<T> : ApiResponse
    {
        public ApiResponse(T data, HttpStatusCode statusCode = HttpStatusCode.OK, string message = null, ApiException unhandledException = null)
            : base((int)statusCode, message, unhandledException)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}
