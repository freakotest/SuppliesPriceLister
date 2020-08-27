using Microsoft.AspNetCore.Mvc;
using Supplier.Api.Shared.OutputModel;
using System.Net;

namespace Supplier.Api.Infrastructure
{
    public static class HttpRequestExtension
    {
        public static IActionResult ToActionResult<T>(this ApiResponse<T> response, string actionName = "", string controllerName = "", object routeValues = null, object value = null)
        {
            return CreateActionResult<T>(response, actionName, controllerName, routeValues, value);
        }

        public static IActionResult CreateActionResult<T>(ApiResponse<T> response, string actionName = "", string controllerName = "", object routeValues = null, object value = null)
        {
            switch (response.StatusCode)
            {
                case (int)HttpStatusCode.Created:
                    return new CreatedAtActionResult(actionName, controllerName, routeValues, value);//TODO routeValues
                case (int)HttpStatusCode.Accepted:
                    return new AcceptedAtActionResult(actionName, controllerName, routeValues, value);
                case (int)HttpStatusCode.OK:
                case (int)HttpStatusCode.NoContent:
                case (int)HttpStatusCode.ResetContent:
                case (int)HttpStatusCode.PartialContent:
                case (int)HttpStatusCode.MultiStatus:
                    return new OkObjectResult(response.Data);
                case (int)HttpStatusCode.NotFound:
                    return new NotFoundObjectResult(response.Message);
                case (int)HttpStatusCode.BadRequest:
                    return new BadRequestObjectResult(response.Message);
                case (int)HttpStatusCode.NotImplemented:
                case (int)HttpStatusCode.FailedDependency:
                default:
                    return new ObjectResult(response.Message) { StatusCode = response.StatusCode };
            }
        }
    }
}
