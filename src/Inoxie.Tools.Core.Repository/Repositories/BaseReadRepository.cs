using Inoxie.Tools.Core.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Inoxie.Tools.Core.Repository.Repositories;

/// <summary>
/// Provides a base implementation for read-only repository operations for a given entity type and its ID type.
/// This class offers fundamental read operations like fetching an entity by its ID, querying entities based on a predicate, 
/// and other common reading functionalities. 
/// The provided methods support both tracking and non-tracking queries, optimizing performance and data manipulation according to the developer's intent.
/// </summary>
/// <typeparam name="TEntity">The type of the entity the repository operates on.</typeparam>
/// <typeparam name="TId">The type of the entity's ID.</typeparam>
public class BaseReadRepository<TEntity, TId> : IBaseReadRepository<TEntity, TId>
    where TEntity : class, IBaseDataEntity<TId>
{
    private readonly DbSet<TEntity> dbSet;

    public BaseReadRepository(
        IDatabaseContextProvider databaseContextProvider)
    {
        dbSet = databaseContextProvider.Get().Set<TEntity>();
    }

    public IQueryable<TEntity> AsQueryable(bool asTracking = false)
    {
        return asTracking ? dbSet.AsQueryable().AsTracking() : dbSet.AsQueryable().AsNoTracking();
    }

    public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool asTracking = false)
    {
        return AsQueryable(asTracking: asTracking).FirstOrDefaultAsync(predicate);
    }

    public Task<TEntity> GetAsync(TId id, bool asTracking = false)
    {
        return AsQueryable(asTracking: asTracking).FirstOrDefaultAsync(f => Equals(f.Id, id));
    }

    public Task<List<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate, bool asTracking = false)
    {
        return AsQueryable(asTracking: asTracking).Where(predicate).ToListAsync();
    }
}