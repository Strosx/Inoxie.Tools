using Inoxie.Tools.Exceptions.Abstractions;
using Inoxie.Tools.Exceptions.Models;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Inoxie.Tools.Exceptions.Services;

internal class ExceptionMiddleware
{
    private readonly ILogger<ExceptionMiddleware> logger;
    private readonly TelemetryClient telemetryClient;
    private readonly RequestDelegate next;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, TelemetryClient telemetryClient)
    {
        this.next = next;
        this.logger = logger;
        this.telemetryClient = telemetryClient;
    }

    public async Task InvokeAsync(
        HttpContext httpContext,
        IMessageFromErrorCodeProvider messageFromErrorCodeProvider)
    {
        try
        {
            await next(httpContext);
        }
        catch (InoxieErrorCodeException ex)
        {
            var message = await messageFromErrorCodeProvider.Get(ex.ErrorCode);
            logger.LogError($"Exception: {message}");
            await HandleExceptionAsync(httpContext, message, ex.ErrorCode);
            telemetryClient.TrackException(ex);
        }
        catch (InoxieException ex)
        {
            logger.LogError($"Exception: {ex.Message}");
            await HandleInoxieExceptionAsync(httpContext, ex);
            telemetryClient.TrackException(ex);
        }
        catch (InoxieForbiddenException ex)
        {
            logger.LogError($"Exception: {ex.Message}");
            await HandleForbiddenExceptionAsync(httpContext, ex);
            telemetryClient.TrackException(ex);
        }
        catch (Exception ex)
        {
            logger.LogError($"Fatal unhandled exception: {ex.Message}");
            await HandleExceptionAsync(httpContext, ex);
            telemetryClient.TrackException(ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        return HandleExceptionAsync(context, $"Unhandled exception: {ex?.Message}");
    }

    private static Task HandleExceptionAsync(
        HttpContext context,
        string message,
        int? errorCode = null,
        HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)httpStatusCode;
        var errorDetails = JsonSerializer.Serialize(new ErrorDetailsOutDto
        {
            StatusCode = context.Response.StatusCode,
            Message = message,
            ErrorCode = errorCode
        });

        return context.Response.WriteAsync(errorDetails);
    }

    private static Task HandleForbiddenExceptionAsync(HttpContext context, InoxieForbiddenException exception)
    {
        return HandleExceptionAsync(context, exception.Message);
    }

    private static Task HandleInoxieExceptionAsync(HttpContext context, InoxieException exception)
    {
        return HandleExceptionAsync(context, exception.Message, exception.ErrorCode);
    }
}
