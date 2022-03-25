using System.Linq.Expressions;

namespace Inoxie.Tools.Core.Repository.Abstractions
{
    public interface IReadRepository<T> where T : IDataEntity
    {
        Task<T> Get(Guid id, bool asTracking = false);
        Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate, bool asTracking = false);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate, bool asTracking = false);
        IQueryable<T> AsQueryable(bool asTracking = false);
    }
}
