using Inoxie.Tools.Core.Repository.Abstractions;
using Inoxie.Tools.Core.Repository.Implementations;
using Inoxie.Tools.Core.Repository.Repositories;
using Inoxie.Tools.Core.Repository.StringId.Abstractions;
using Inoxie.Tools.Core.Repository.StringId.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Inoxie.Tools.Core.Repository.StringId.DI;

/// <summary>
/// Provides internal mechanisms to configure the services necessary for repositories with string-based ID.
/// </summary>
internal static class RepositoryDependencyInjection
{
    /// <summary>
    /// Registers the required services for the string-based ID repository implementations within the provided service collection.
    /// </summary>
    /// <typeparam name="TDatabaseContext">The type of the database context the repository will operate on.</typeparam>
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
/// Contains extensions for registering the necessary services for string-based ID repositories.
/// </summary>
public static class InoxieToolsRepositoryStringIdExtensions
{
    /// <summary>
    /// Registers the required services for repositories with string-based ID within the provided service collection.
    /// </summary>
    /// <typeparam name="TDatabaseContext">The type of the database context the repository will operate on.</typeparam>
    /// <param name="services">The service collection to add the services to.</param>
    public static void AddInoxieRepositoryStringId<TDatabaseContext>(this IServiceCollection services)
        where TDatabaseContext : DbContext
    {
        RepositoryDependencyInjection.Configure<TDatabaseContext>(services);
    }
}