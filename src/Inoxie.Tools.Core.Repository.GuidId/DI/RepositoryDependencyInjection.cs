using Inoxie.Tools.Core.Repository.Abstractions;
using Inoxie.Tools.Core.Repository.GuidId.Abstractions;
using Inoxie.Tools.Core.Repository.GuidId.Repositories;
using Inoxie.Tools.Core.Repository.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Inoxie.Tools.Core.Repository.GuidId.DI;

internal static class RepositoryDependencyInjection
{
    public static void Configure<TDatabaseContext>(IServiceCollection services) where TDatabaseContext : DbContext
    {
        services.AddTransient(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddTransient(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        services.AddTransient<IDatabaseContextProvider, DatabaseContextProvider<TDatabaseContext>>();
    }
}

public static class InoxieToolsRepositoryGuidIdExtensions
{
    public static void AddInoxieRepositoryGuidId<TDatabaseContext>(this IServiceCollection services)
        where TDatabaseContext : DbContext
    {
        RepositoryDependencyInjection.Configure<TDatabaseContext>(services);
    }
}