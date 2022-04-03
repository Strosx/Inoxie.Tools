using Inoxie.Tools.DataProcessor.Abstractions.Interfaces;
using Inoxie.Tools.DataProcessor.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Inoxie.Tools.DataProcessor.DI;

internal static class DataProcessorDependencyInjection
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped(typeof(IDataProcessor<,>), typeof(DataProcessor<,>));
        services.AddScoped(typeof(IDataProcessorFilterProvider<,>), typeof(DefaultFilterProvider<,>));
    }
}

public static class DataProcessorExtensions
{
    public static void AddInoxieDataProcessor(this IServiceCollection services)
    {
        DataProcessorDependencyInjection.ConfigureServices(services);
    }
}

