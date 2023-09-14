using Inoxie.Tools.DataProcessor.Abstractions.Interfaces;
using Inoxie.Tools.DataProcessor.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Inoxie.Tools.DataProcessor.DI;

/// <summary>
/// Provides dependency injection configurations for the DataProcessor toolset.
/// </summary>
internal static class DataProcessorDependencyInjection
{
    /// <summary>
    /// Configures and registers DataProcessor services and related dependencies.
    /// </summary>
    /// <param name="services">The service collection used for registering services.</param>
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped(typeof(IDataProcessor<,>), typeof(DataProcessor<,>));
        services.AddScoped(typeof(IDataProcessorFilterProvider<,>), typeof(DefaultFilterProvider<,>));
    }
}

public static class DataProcessorExtensions
{
    /// <summary>
    /// Configures the necessary services for Inoxie Data Processor within the given services collection.
    /// This will inject IDataProcessor and IDataProcessorFilterProvider with their respective default implementations.
    /// </summary>
    /// <param name="services">The IServiceCollection to add the services to.</param>
    public static void AddInoxieDataProcessor(this IServiceCollection services)
    {
        DataProcessorDependencyInjection.ConfigureServices(services);
    }
}