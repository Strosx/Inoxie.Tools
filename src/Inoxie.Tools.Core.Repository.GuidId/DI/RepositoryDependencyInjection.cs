using Inoxie.Tools.Core.Repository.DI;
using Inoxie.Tools.Core.Repository.GuidId.Abstractions;
using Inoxie.Tools.Core.Repository.GuidId.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Inoxie.Tools.Core.Repository.GuidId.DI;

internal static class RepositoryDependencyInjection
{
    public static void Configure<TDatabaseContext>(IServiceCollection services)
        where TDatabaseContext : DbContext
    {
        services.AddTransient(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddTransient(typeof(IWriteRepository<>), typeof(WriteRepository<>));
    }
}

public static class InoxieToolsRepositoryGuidIdExtensions
{
    public static void AddInoxieRepositoryGuidId<TDatabaseContext>(this IServiceCollection services)
        where TDatabaseContext : DbContext
    {
        services.AddInoxieRepository<TDatabaseContext>();
        RepositoryDependencyInjection.Configure<TDatabaseContext>(services);
    }
}