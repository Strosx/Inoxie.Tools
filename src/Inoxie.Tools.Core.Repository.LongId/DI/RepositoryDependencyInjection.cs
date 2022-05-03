using Inoxie.Tools.Core.Repository.Abstractions;
using Inoxie.Tools.Core.Repository.Implementations;
using Inoxie.Tools.Core.Repository.LongId.Abstractions;
using Inoxie.Tools.Core.Repository.LongId.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Inoxie.Tools.Core.Repository.LongId.DI;

internal static class RepositoryDependencyInjection
{
    public static void Configure<TDatabaseContext>(IServiceCollection services) where TDatabaseContext : DbContext
    {
        services.AddTransient(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddTransient(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        services.AddTransient<IDatabaseContextProvider, DatabaseContextProvider<TDatabaseContext>>();
    }
}

public static class InoxieToolsRepositoryLongIdExtensions
{
    public static void AddInoxieRepositoryLongId<TDatabaseContext>(this IServiceCollection services)
        where TDatabaseContext : DbContext
    {
        RepositoryDependencyInjection.Configure<TDatabaseContext>(services);
    }
}