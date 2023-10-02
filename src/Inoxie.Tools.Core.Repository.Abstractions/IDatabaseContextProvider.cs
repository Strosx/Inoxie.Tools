using Microsoft.EntityFrameworkCore;

namespace Inoxie.Tools.Core.Repository.Abstractions;

/// <summary>
/// Provides a mechanism to obtain instances of the database context.
/// This interface is used to avoid directly injecting the database context into repositories, 
/// promoting a decoupling from the direct dependency on the database.
/// Instead, repositories access the database context through this provider.
/// </summary>
public interface IDatabaseContextProvider
{
    /// <summary>
    /// Retrieves an instance of the <see cref="DbContext"/>.
    /// </summary>
    /// <returns>An instance of the <see cref="DbContext"/>.</returns>
    DbContext Get();
}