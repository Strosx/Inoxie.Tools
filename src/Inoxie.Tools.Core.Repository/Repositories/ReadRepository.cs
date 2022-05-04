using Inoxie.Tools.Core.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Inoxie.Tools.Core.Repository.Repositories;

public class ReadRepository<TEntity, TId> : IReadRepository<TEntity, TId>
    where TEntity : class, IDataEntity<TId>
{
    private readonly DbSet<TEntity> dbSet;

    public ReadRepository(
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