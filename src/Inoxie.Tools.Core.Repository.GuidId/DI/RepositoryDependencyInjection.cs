using Inoxie.Tools.Core.Repository.Abstractions;
using Inoxie.Tools.Core.Repository.GuidId.Abstractions;
using Inoxie.Tools.Core.Repository.GuidId.Repositories;
using Inoxie.Tools.Core.Repository.Implementations;
using Inoxie.Tools.Core.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Inoxie.Tools.Core.Repository.GuidId.DI;

/// <summary>
/// Handles the registration of services and repositories that operate on entities with GUID identifiers.
/// </summary>
internal static class RepositoryDependencyInjection
{  
    /// <summary>
    /// Configures services for the repository pattern for entities using GUIDs.
    /// </summary>
    /// <typeparam name="TDatabaseContext">Type of the database context, derived from <see cref="DbContext"/>.</typeparam>
    /// <param name="services">The services collection to add to.</param>
    public static void Configure<TDatabaseContext>(IServiceCollection services) where TDatabaseContext : DbContext
    {
        services.AddTransient(typeof(IDbSaveChanges), typeof(DbSaveChanges));
        services.AddTransient(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddTransient(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        services.AddTransient<IDatabaseContextProvider, DatabaseContextProvider<TDatabaseContext>>();
    }
}

/// <summary>
/// Extension methods for service collection to easily register GUID ID repository components.
/// </summary>
public static class InoxieToolsRepositoryGuidIdExtensions
{  
    /// <summary>
    /// Adds repository services for entities that use GUIDs as their primary identifiers.
    /// </summary>
    /// <typeparam name="TDatabaseContext">Type of the database context, derived from <see cref="DbContext"/>.</typeparam>
    /// <param name="services">The services collection to add to.</param>
    public static void AddInoxieRepositoryGuidId<TDatabaseContext>(this IServiceCollection services)
        where TDatabaseContext : DbContext
    {
        RepositoryDependencyInjection.Configure<TDatabaseContext>(services);
    }
}