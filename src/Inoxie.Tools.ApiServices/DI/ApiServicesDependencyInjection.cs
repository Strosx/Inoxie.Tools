using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.ApiServices.Services;
using Inoxie.Tools.DataProcessor.DI;
using Microsoft.Extensions.DependencyInjection;

namespace Inoxie.Tools.ApiServices.DI;

internal static class ApiServicesDependencyInjection
{
    public static void Configure(IServiceCollection services)
    {
        services.AddInoxieDataProcessor();
        services.AddScoped(typeof(IReadAuthorizationService<,>), typeof(DefaultReadAuthorizationService<,>));
        services.AddScoped(typeof(IReadServicePostProcessor<>), typeof(DefaultReadServicePostProcessor<>));
        services.AddScoped(typeof(IWriteAuthorizationService<,>), typeof(DefaultWriteAuthorizationService<,>));
    }
}