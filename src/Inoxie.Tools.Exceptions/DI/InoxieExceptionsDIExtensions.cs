using Inoxie.Tools.Exceptions.Abstractions;
using Inoxie.Tools.Exceptions.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Inoxie.Tools.Exceptions.DI;

public static class InoxieExceptionsDIExtensions
{
    public static void AddInoxieExceptions(this IServiceCollection services)
    {
        services.AddApplicationInsightsTelemetry();
        services.AddScoped<IMessageFromErrorCodeProvider, DefaultMessageFromErrorCodeProvider>();
    }

    public static void AddInoxieExceptions<TErrorCodeMessageProvider>(this IServiceCollection services)
       where TErrorCodeMessageProvider : class, IMessageFromErrorCodeProvider
    {
        services.AddApplicationInsightsTelemetry();
        services.AddScoped<IMessageFromErrorCodeProvider, TErrorCodeMessageProvider>();
    }

    public static void UseInoxieExceptions(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}

