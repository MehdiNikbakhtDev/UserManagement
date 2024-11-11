using FluentResults;
using Newtonsoft.Json;
using System.Net;

namespace API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public ExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
    {
        //_logger = loggerFactory.CreateLogger<ExceptionMiddleware>();
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {

            if (ex != null && !string.IsNullOrEmpty(ex.InnerException?.Message))
            {
                var myMsg = ex.InnerException.Message.Split("Message=").LastOrDefault();
                await HandleExceptionAsync(httpContext, ex, myMsg);
            }
            else
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception ex, string message = "")
    {
        Result result = new Result();
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        //_logger.LogError(ex, "خطا" + message);
        var response = result.WithError(string.IsNullOrEmpty(message) ? ex.Message : message);
        return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
    }
}
