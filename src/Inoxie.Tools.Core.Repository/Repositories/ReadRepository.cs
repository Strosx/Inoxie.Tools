using Inoxie.Tools.Core.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Inoxie.Tools.Core.Repository.Repositories;

public class ReadRepository<T> : IReadRepository<T>
    where T : class, IDataEntity
{
    private readonly DbSet<T> dbSet;

    public ReadRepository(
        IDatabaseContextProvider databaseContextProvider)
    {
        dbSet = databaseContextProvider.Get().Set<T>();
    }

    public IQueryable<T> AsQueryable(bool asTracking = false)
    {
        return asTracking ? dbSet.AsQueryable().AsTracking() : dbSet.AsQueryable().AsNoTracking();
    }

    public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, bool asTracking = false)
    {
        return AsQueryable(asTracking: asTracking).FirstOrDefaultAsync(predicate);
    }

    public Task<T> GetAsync(Guid id, bool asTracking = false)
    {
        return AsQueryable(asTracking: asTracking).FirstOrDefaultAsync(f => f.Id == id);
    }

    public Task<List<T>> WhereAsync(Expression<Func<T, bool>> predicate, bool asTracking = false)
    {
        return AsQueryable(asTracking: asTracking).Where(predicate).ToListAsync();
    }
}
