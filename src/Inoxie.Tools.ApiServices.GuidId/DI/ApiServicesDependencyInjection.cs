using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.ApiServices.GuidId.Abstractions;
using Inoxie.Tools.ApiServices.GuidId.Services;
using Inoxie.Tools.ApiServices.Services;
using Inoxie.Tools.Core.Repository.GuidId.Abstractions;
using Inoxie.Tools.Core.Repository.GuidId.DI;
using Inoxie.Tools.DataProcessor.Abstractions.Interfaces;
using Inoxie.Tools.DataProcessor.Abstractions.Models;
using Inoxie.Tools.DataProcessor.DI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Inoxie.Tools.ApiServices.GuidId.DI;

internal static class ApiServicesDependencyInjection
{
    public static void Configure<TContext>(IServiceCollection services)
        where TContext : DbContext
    {
        services.AddInoxieRepositoryGuidId<TContext>();

        services.AddInoxieDataProcessor();
        services.AddScoped(typeof(IReadAuthorizationService<>), typeof(DefaultReadAuthorizationService<>));
        services.AddScoped(typeof(IReadServicePostProcessor<>), typeof(DefaultReadServicePostProcessor<>));
        services.AddScoped(typeof(IWriteAuthorizationService<>), typeof(DefaultWriteAuthorizationService<>));
    }
}

public static class ApiServicesDependencyInjectionGuidIdExtensions
{
    public static void AddInoxieApiServicesGuidId<TContext>(this IServiceCollection services)
        where TContext : DbContext
    {
        ApiServicesDependencyInjection.Configure<TContext>(services);
    }
    
    public static void AddFilteredReadService<TEntity, TOutDto, TFilter>(this IServiceCollection services)
        where TEntity : class, IDataEntity
        where TFilter : BaseFilterModel
        where TOutDto : class
    {
        services.AddScoped<IFilterReadService<TOutDto, TFilter>, FilteredReadService<TEntity, TOutDto, TFilter>>();
    }

    public static void AddFilteredReadService<TEntity, TOutDto, TFilter, TFilterProvider>(this IServiceCollection services)
        where TEntity : class, IDataEntity
        where TFilter : BaseFilterModel
        where TOutDto : class
        where TFilterProvider : class, IDataProcessorFilterProvider<TEntity, TFilter>
    {
        services.AddScoped<IFilterReadService<TOutDto, TFilter>, FilteredReadService<TEntity, TOutDto, TFilter>>();
        services.AddScoped<IDataProcessorFilterProvider<TEntity, TFilter>, TFilterProvider>();
    }

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
    
    public static void AddReadService<TEntity, TOutDto>(this IServiceCollection services)
        where TEntity : IDataEntity
    {
        services.AddScoped<IReadService<TOutDto>, ReadService<TEntity, TOutDto>>();
    }

    public static void AddWriteService<TEntity, TInDto>(this IServiceCollection services)
        where TEntity : IDataEntity
    {
        services.AddScoped<IWriteService<TInDto>, WriteService<TEntity, TInDto>>();
    }

    public static void AddWriteService<TEntity, TInDto, TWriteAuthorizationService>(this IServiceCollection services)
        where TEntity : IDataEntity
        where TWriteAuthorizationService : class, IWriteAuthorizationService<TInDto>
    {
        services.AddScoped<IWriteService<TInDto>, WriteService<TEntity, TInDto>>();
        services.AddScoped<IWriteAuthorizationService<TInDto>, TWriteAuthorizationService>();
    }
}