using HouseRentWebApi.Shared.Exceptions;
using HouseRentWebApi.Shared.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;

namespace HouseRentWebApi.Shared.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
                var name = typeof(ExceptionHandlerMiddleware).Name;
                _logger.LogError($"Error on : {name}", ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var errorCode = 500;
            var result = string.Empty;
            ResponseMessage<string> response = new ResponseMessage<string>();

            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.OK;
                    errorCode = 422;
                    result = JsonConvert.SerializeObject(validationException.Failures);
                    break;

                case BadRequestException badRequestException:
                    code = HttpStatusCode.OK;
                    errorCode = 400;
                    result = badRequestException.Message;
                    break;

                case NotFoundException notFoundException:
                    code = HttpStatusCode.OK;
                    errorCode = 404;
                    result = notFoundException.Message;
                    break;

                case UnAuthorizedException unAuthorized:
                    code = HttpStatusCode.Unauthorized;
                    result = unAuthorized.Message;
                    errorCode = 401;
                    break;

                case DeleteFailureException deleteFailureException:
                    code = HttpStatusCode.Forbidden;
                    errorCode = 403;
                    result = deleteFailureException.Message;
                    break;
            }

            if (exception.Message.Contains("foreign key is not nullable"))
            {
                code = (HttpStatusCode)547;
                result = "The record cannot be deleted because it is associated with another record.";
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            response.ErrorMessage = result != string.Empty ? result : exception.Message;
            response.StatusCode = (int)code;
            response.ErrorCode = errorCode;
            response.MessageType = MessageType.Error;

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }));

        }
    }

    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}