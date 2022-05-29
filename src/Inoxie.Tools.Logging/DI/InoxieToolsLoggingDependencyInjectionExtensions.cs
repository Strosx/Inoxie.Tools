using Inoxie.Tools.Logging.Interfaces;
using Inoxie.Tools.Logging.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Inoxie.Tools.Logging.DI;

public static class InoxieToolsLoggingDependencyInjectionExtensions
{
    public static void AddInoxieToolsLogging(this IServiceCollection services)
    {
        services.AddLogging()
            .AddApplicationInsightsTelemetry();

        services.AddSingleton(typeof(IInoxieLogger<>), typeof(InoxieLogger<>));
    }
}
