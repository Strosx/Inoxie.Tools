using Inoxie.Tools.Core.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Inoxie.Tools.Core.Repository.Repositories
{
    internal class BaseReadRepository<T> : IReadRepository<T>
        where T : class, IDataEntity
    {
        private readonly DbSet<T> dbSet;

        public BaseReadRepository(
            IDatabaseContextProvider databaseContextProvider)
        {
            dbSet = databaseContextProvider.Get().Set<T>();
        }

        public IQueryable<T> AsQueryable(bool asTracking = false)
        {
            return asTracking ? dbSet.AsQueryable().AsTracking() : dbSet.AsQueryable().AsNoTracking();
        }

        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate, bool asTracking = false)
        {
            return await AsQueryable(asTracking: asTracking).FirstOrDefaultAsync(predicate);
        }

        public async Task<T> Get(Guid id, bool asTracking = false)
        {
            return await AsQueryable(asTracking: asTracking).FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate, bool asTracking = false)
        {
            return await AsQueryable(asTracking: asTracking).Where(predicate).ToArrayAsync();
        }
    }
}
