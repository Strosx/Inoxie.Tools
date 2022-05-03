﻿using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.ApiServices.Services;
using Inoxie.Tools.Core.Repository.Abstractions;
using Inoxie.Tools.DataProcessor.Abstractions.Interfaces;
using Inoxie.Tools.DataProcessor.Abstractions.Models;
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

public static class ApiServicesDependencyInjectionExtensions
{
    public static void AddInoxieApiServices(this IServiceCollection services)
    {
        ApiServicesDependencyInjection.Configure(services);
    }

    public static void AddWriteService<TEntity, TInDto>(this IServiceCollection services)
        where TEntity : IDataEntity<TId>
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

    public static void AddReadService<TEntity, TOutDto>(this IServiceCollection services)
        where TEntity : IDataEntity
    {
        services.AddScoped<IReadService<TOutDto>, ReadService<TEntity, TOutDto>>();
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

}
