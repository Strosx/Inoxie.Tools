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
        services.AddScoped(typeof(IAuthorizationExpressionProvider<>), typeof(DefaultAuthorizationExpressionProvider<>));
    }
}

public static class ApiServicesDependencyInjectionExtenstions
{
    public static void AddApiServices(this IServiceCollection services)
    {
        ApiServicesDependencyInjection.Configure(services);
    }
}
