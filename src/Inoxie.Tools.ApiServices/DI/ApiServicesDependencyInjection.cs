using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.ApiServices.Services;
using Inoxie.Tools.Core.Repository.Abstractions;
using Inoxie.Tools.DataProcessor.Abstractions.Models;
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

    public static void AddWriteService<TEntity, TInDto>(this IServiceCollection services)
        where TEntity : IDataEntity
    {
        services.AddScoped<IWriteService<TInDto>, WriteService<TEntity, TInDto>>();
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
}
