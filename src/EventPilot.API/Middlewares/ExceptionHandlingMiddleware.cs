using System.Net;
using EventPilot.Application.DTOs.Responses;
using EventPilot.Domain.Exceptions;
using EventPilot.Utils;

namespace EventPilot.Middlewares;

public class ExceptionHandlingMiddleware(
    RequestDelegate next,
    IWebHostEnvironment env,
    ILogger<ExceptionHandlingMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly IWebHostEnvironment _env = env;
    private  readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;
    
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (DomainException ex)
        {
            await HandleDomainExceptionAsync(context, ex);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }


    private static Task HandleDomainExceptionAsync(HttpContext context, DomainException exception)
    {
        // Parse error -> status
        var (statusCode, title) = ExceptionMapper.Map(exception);

        var response = new ErrorResponse()
        {
            Title = title,
            Status = statusCode,
            Detail = exception.Message,
            Instance = context.Request.Path
        };

        return SendResponse(
            context: context,
            errorResponse: response
        );
    }


    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        // logs
        _logger.LogError(exception, "Unexpected exception");
        
        var statusCode = HttpStatusCode.InternalServerError;

        var response = new ErrorResponse()
        {
            Title = "Internal Server Error",
            Status = (int)statusCode,
            Detail = "Something went wrong",
            Instance = context.Request.Path
        };

        if (_env.IsDevelopment())
        {
            response.StackTrace = exception.ToString();
        }

        return SendResponse(
            context: context,
            errorResponse: response
        );
    }


    private static Task SendResponse(
        HttpContext context,
        ErrorResponse errorResponse
    )
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = errorResponse.Status;

        return context.Response.WriteAsJsonAsync(errorResponse);
    }
}
