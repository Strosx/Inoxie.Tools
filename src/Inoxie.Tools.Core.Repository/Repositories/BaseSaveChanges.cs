using Inoxie.Tools.Core.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Inoxie.Tools.Core.Repository.Repositories;

/// <summary>
/// Serves as the primary mechanism to save changes within an Entity Framework database context.
/// </summary>
public class DbSaveChanges : IDbSaveChanges
{
    private readonly DbContext context;

    public DbSaveChanges(IDatabaseContextProvider databaseContextProvider)
    {
        context = databaseContextProvider.Get();
    }

    public async Task SaveChangesAsync(Action<DbContext> action = null)
    {
        action?.Invoke(context);
        await context.SaveChangesAsync();
    }
}