using System.Net;
using CleanArchitecture.Api.Errors;
using CleanArchitecture.Application.Exceptions;
using Newtonsoft.Json;

namespace CleanArchitecture.Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IHostEnvironment _environment;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment environment)
    {
        _next = next;
        _logger = logger;
        _environment = environment;
    }

    public async Task Invokesync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, message: ex.Message);
            context.Response.ContentType = "application/json";
            var statusCode = (int)HttpStatusCode.InternalServerError;
            var result = string.Empty;

            switch (ex)
            {
                case NotFoundException notFoundException:
                    statusCode = (int)HttpStatusCode.NotFound;
                    break;
                    
                case ValidationException validationException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    var validationJson = JsonConvert.SerializeObject(validationException.Errors);
                    result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, ex.Message,
                        validationJson));
                    break;
                
                case BadHttpRequestException badHttpRequestException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    break;
                
                default:
                    break;
            }

            if (string.IsNullOrEmpty(result))
                result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, ex.Message, ex.StackTrace));

            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsync(result);
        }
    }
}