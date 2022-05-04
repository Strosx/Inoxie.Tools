using System.Linq.Expressions;

namespace Inoxie.Tools.Core.Repository.Abstractions;

public interface IBaseReadRepository<TEntity, in TId> where TEntity : IBaseDataEntity<TId>
{
    Task<TEntity> GetAsync(TId id, bool asTracking = false);
    Task<List<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate, bool asTracking = false);
    Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool asTracking = false);
    IQueryable<TEntity> AsQueryable(bool asTracking = false);
}
