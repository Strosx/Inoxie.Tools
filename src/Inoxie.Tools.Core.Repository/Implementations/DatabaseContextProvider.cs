using Inoxie.Tools.Core.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Inoxie.Tools.Core.Repository.Implementations;

/// <summary>
/// Supplies the designated database context for operations within the repository.
/// </summary>
/// <typeparam name="TDatabaseContext">Type of the database context.</typeparam>
internal class DatabaseContextProvider<TDatabaseContext> : IDatabaseContextProvider
    where TDatabaseContext : DbContext
{
    private readonly TDatabaseContext context;

    public DatabaseContextProvider(TDatabaseContext context)
    {
        this.context = context;
    }
    public DbContext Get()
    {
        return context;
    }
}
