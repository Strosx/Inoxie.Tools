using System.Linq.Expressions;

namespace Inoxie.Tools.Core.Repository.Abstractions;

public interface IReadRepository<T, in TId> where T : IDataEntity<TId>
{
    Task<T> GetAsync(TId id, bool asTracking = false);
    Task<List<T>> WhereAsync(Expression<Func<T, bool>> predicate, bool asTracking = false);
    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, bool asTracking = false);
    IQueryable<T> AsQueryable(bool asTracking = false);
}
