using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Supplier.Api.Shared.OutputModel;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Supplier.Api.Infrastructure
{
    public class ExceptionHandlerMiddleware
    {
        private const string JsonContentType = "application/json";
        private readonly RequestDelegate _request;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionHandlerMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next.</param>
        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _request = next;
            _logger = logger;
        }

        /// <summary>
        /// Invokes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public Task Invoke(HttpContext context) => this.InvokeAsync(context);

        async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this._request(context);
            }
            catch (Exception exception)
            {
                var statuscode = (int)HttpStatusCode.InternalServerError;
                // set http status code and content type

                context.Response.StatusCode = statuscode; //might want to be more specific about the http error code
                context.Response.ContentType = JsonContentType;

                await HandleExceptionAsync(context, exception, statuscode, true);//TODO config verbose error
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception, int httpStatusCode, bool verbose)
        {
            var message = exception.Message;

            var apiException = verbose == true ? new ApiException(exception, httpStatusCode) : null;
            _logger.Log(LogLevel.Error, $"HandleExceptionAsync : httpStatusCode : {httpStatusCode} message: {message}");
            var response = new ApiResponse(httpStatusCode, message, apiException);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = httpStatusCode;

            // writes / returns error model to the response
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            }));
            context.Response.Headers.Clear();
        }
    }
}
