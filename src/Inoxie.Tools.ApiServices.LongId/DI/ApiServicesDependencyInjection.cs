using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.ApiServices.LongId.Abstractions;
using Inoxie.Tools.ApiServices.LongId.Services;
using Inoxie.Tools.ApiServices.Services;
using Inoxie.Tools.Core.Repository.LongId.Abstractions;
using Inoxie.Tools.Core.Repository.LongId.DI;
using Inoxie.Tools.DataProcessor.Abstractions.Interfaces;
using Inoxie.Tools.DataProcessor.Abstractions.Models;
using Inoxie.Tools.DataProcessor.DI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Inoxie.Tools.ApiServices.LongId.DI;

internal static class ApiServicesDependencyInjection
{
    /// <summary>
    /// Configures necessary services like repositories, data processors, and default implementations for the given context.
    /// </summary>
    /// <typeparam name="TContext">The type of the DbContext that will be used for data operations.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    public static void Configure<TContext>(IServiceCollection services)
        where TContext : DbContext
    {
        services.AddInoxieRepositoryLongId<TContext>();

        services.AddInoxieDataProcessor();
        services.AddScoped(typeof(IReadAuthorizationService<>), typeof(DefaultReadAuthorizationService<>));
        services.AddScoped(typeof(IReadServicePostProcessor<>), typeof(DefaultReadServicePostProcessor<>));
        services.AddScoped(typeof(IWriteAuthorizationService<>), typeof(DefaultWriteAuthorizationService<>));
    }
}

public static class ApiServicesDependencyInjectionLongIdExtensions
{
    /// <summary>
    /// Adds base implementations for services, repositories, and data processors.
    /// It is the primary method for setting up the default services required by the API.
    /// </summary>
    /// <typeparam name="TContext">The type of the DbContext that will be used for data operations.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <remarks>
    /// This method should be called in the Startup class within the ConfigureServices method to ensure all required services are registered.
    /// </remarks>
    public static void AddInoxieApiServicesLongId<TContext>(this IServiceCollection services)
        where TContext : DbContext
    {
        ApiServicesDependencyInjection.Configure<TContext>(services);
    }

    /// <summary>
    /// Registers a filtered read service using a base filter model for the specified entity and DTO.
    /// </summary>
    /// <remarks>
    /// This method configures a read service that uses the standard BaseFilterModel for data filtering. Customization of the filter logic is not provided in this overload.
    /// </remarks>
    /// <typeparam name="TEntity">The type of the entity that the service will operate on.</typeparam>
    /// <typeparam name="TOutDto">The type of the DTO that will be returned by the service.</typeparam>
    /// <param name="services">The collection of services to which the filtered read service will be added.</param>
    public static void AddFilteredReadService<TEntity, TOutDto>(this IServiceCollection services)
        where TEntity : class, IDataEntity
        where TOutDto : class
    {
        services.AddScoped<IFilterReadService<TOutDto, BaseFilterModel>, FilteredReadService<TEntity, TOutDto, BaseFilterModel>>();
    }

    /// <summary>
    /// Registers a filtered read service with a custom filter provider.
    /// </summary>
    /// <typeparam name="TEntity">The entity type for the service.</typeparam>
    /// <typeparam name="TOutDto">The DTO returned by the service.</typeparam>
    /// <typeparam name="TFilter">The filter model type used for data filtering.</typeparam>
    /// <typeparam name="TFilterProvider">The custom filter provider.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    public static void AddFilteredReadService<TEntity, TOutDto, TFilter, TFilterProvider>(this IServiceCollection services)
        where TEntity : class, IDataEntity
        where TFilter : BaseFilterModel
        where TOutDto : class
        where TFilterProvider : class, IDataProcessorFilterProvider<TEntity, TFilter>
    {
        services.AddScoped<IFilterReadService<TOutDto, TFilter>, FilteredReadService<TEntity, TOutDto, TFilter>>();
        services.AddScoped<IDataProcessorFilterProvider<TEntity, TFilter>, TFilterProvider>();
    }

    /// <summary>
    /// Registers a filtered read service with a custom filter provider and read authorization service.
    /// </summary>
    /// <remarks>
    /// This overload allows for additional customization by providing a custom read authorization service.
    /// </remarks>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    public static void AddFilteredReadService<TEntity, TOutDto, TFilter, TFilterProvider, TReadAuthorizationService>(this IServiceCollection services)
        where TEntity : class, IDataEntity
        where TFilter : BaseFilterModel
        where TOutDto : class
        where TFilterProvider : class, IDataProcessorFilterProvider<TEntity, TFilter>
        where TReadAuthorizationService : class, IReadAuthorizationService<TEntity>
    {
        services.AddScoped<IFilterReadService<TOutDto, TFilter>, FilteredReadService<TEntity, TOutDto, TFilter>>();
        services.AddScoped<IDataProcessorFilterProvider<TEntity, TFilter>, TFilterProvider>();
        services.AddScoped<IReadAuthorizationService<TEntity>, TReadAuthorizationService>();
    }

    /// <summary>
    /// Registers a filtered read service with a custom filter provider, read authorization service, and post-read processing.
    /// </summary>
    /// <remarks>
    /// This overload provides the maximum flexibility by allowing for a custom filter provider, read authorization, and post-read processing.
    /// </remarks>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    public static void AddFilteredReadService<TEntity, TOutDto, TFilter,
        TFilterProvider, TReadAuthorizationService, TReadServicePostProcessor>(this IServiceCollection services)
        where TEntity : class, IDataEntity
        where TFilter : BaseFilterModel
        where TOutDto : class
        where TFilterProvider : class, IDataProcessorFilterProvider<TEntity, TFilter>
        where TReadAuthorizationService : class, IReadAuthorizationService<TEntity>
        where TReadServicePostProcessor : class, IReadServicePostProcessor<TOutDto>
    {
        services.AddScoped<IFilterReadService<TOutDto, TFilter>, FilteredReadService<TEntity, TOutDto, TFilter>>();
        services.AddScoped<IDataProcessorFilterProvider<TEntity, TFilter>, TFilterProvider>();
        services.AddScoped<IReadAuthorizationService<TEntity>, TReadAuthorizationService>();
        services.AddScoped<IReadServicePostProcessor<TOutDto>, TReadServicePostProcessor>();
    }

    /// <summary>
    /// Registers a basic read service for the specified entity and DTO.
    /// </summary>
    /// <typeparam name="TEntity">The entity type for the service.</typeparam>
    /// <typeparam name="TOutDto">The DTO returned by the service.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    public static void AddReadService<TEntity, TOutDto>(this IServiceCollection services)
        where TEntity : IDataEntity
    {
        services.AddScoped<IReadService<TOutDto>, ReadService<TEntity, TOutDto>>();
    }

    /// <summary>
    /// Registers a write service for the specified entity and input DTO.
    /// </summary>
    /// <typeparam name="TEntity">The entity type for the service.</typeparam>
    /// <typeparam name="TInDto">The input DTO type for the service.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    public static void AddWriteService<TEntity, TInDto>(this IServiceCollection services)
        where TEntity : IDataEntity
    {
        services.AddScoped<IWriteService<TInDto>, WriteService<TEntity, TInDto>>();
    }

    /// <summary>
    /// Registers a write service with custom write authorization for the specified entity and input DTO.
    /// </summary>
    /// <typeparam name="TEntity">The entity type for the service.</typeparam>
    /// <typeparam name="TInDto">The input DTO type for the service.</typeparam>
    /// <typeparam name="TWriteAuthorizationService">The custom write authorization service.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    public static void AddWriteService<TEntity, TInDto, TWriteAuthorizationService>(this IServiceCollection services)
        where TEntity : IDataEntity
        where TWriteAuthorizationService : class, IWriteAuthorizationService<TInDto>
    {
        services.AddScoped<IWriteService<TInDto>, WriteService<TEntity, TInDto>>();
        services.AddScoped<IWriteAuthorizationService<TInDto>, TWriteAuthorizationService>();
    }
}