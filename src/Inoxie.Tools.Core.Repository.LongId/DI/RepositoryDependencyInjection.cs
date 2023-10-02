using Inoxie.Tools.Core.Repository.Abstractions;
using Inoxie.Tools.Core.Repository.Implementations;
using Inoxie.Tools.Core.Repository.LongId.Abstractions;
using Inoxie.Tools.Core.Repository.LongId.Repositories;
using Inoxie.Tools.Core.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Inoxie.Tools.Core.Repository.LongId.DI;

/// <summary>
/// Provides methods for configuring dependency injection for repositories using long IDs.
/// </summary>
internal static class RepositoryDependencyInjection
{
    /// <summary>
    /// Configures services for repositories that use long IDs.
    /// </summary>
    /// <typeparam name="TDatabaseContext">The type of the database context.</typeparam>
    /// <param name="services">The service collection to add the services to.</param>
    public static void Configure<TDatabaseContext>(IServiceCollection services) where TDatabaseContext : DbContext
    {
        services.AddTransient(typeof(IDbSaveChanges), typeof(DbSaveChanges));
        services.AddTransient(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddTransient(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        services.AddTransient<IDatabaseContextProvider, DatabaseContextProvider<TDatabaseContext>>();
    }
}

/// <summary>
/// Extension methods for configuring Inoxie's long ID repository services.
/// </summary>
public static class InoxieToolsRepositoryLongIdExtensions
{    
    /// <summary>
    /// Adds and configures services for repositories that use long IDs.
    /// </summary>
    /// <typeparam name="TDatabaseContext">The type of the database context.</typeparam>
    /// <param name="services">The service collection to add the services to.</param>
    public static void AddInoxieRepositoryLongId<TDatabaseContext>(this IServiceCollection services)
        where TDatabaseContext : DbContext
    {
        RepositoryDependencyInjection.Configure<TDatabaseContext>(services);
    }
}