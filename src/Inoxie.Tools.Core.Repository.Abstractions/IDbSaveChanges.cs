using Microsoft.EntityFrameworkCore;

namespace Inoxie.Tools.Core.Repository.Abstractions;

/// <summary>
/// Defines a contract for saving database changes. This interface operates only on tracked entities.
/// </summary>
public interface IDbSaveChanges
{
    /// <summary>
    /// Asynchronously saves all changes made in the context on tracked entities.
    /// If an optional action is provided, it will be executed on the tracked entities before saving the changes.
    /// </summary>
    /// <param name="action">An optional action to be executed on the DbContext (specifically on tracked entities) before saving. Default is null.</param>
    /// <returns>A task that represents the asynchronous save operation.</returns>
    Task SaveChangesAsync(Action<DbContext> action = null);
}