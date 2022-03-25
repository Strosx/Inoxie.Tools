using Inoxie.Tools.Core.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Inoxie.Tools.Core.Repository.Repositories
{
    internal class BaseWriteRepository<T> : IWriteRepository<T>
        where T : class, IDataEntity
    {
        private readonly DbContext context;
        private readonly DbSet<T> dbSet;
        private readonly IUpdateMapping<T> updateMapping;

        public BaseWriteRepository(
            IDatabaseContextProvider databaseContextProvider,
            IUpdateMapping<T> updateMapping)
        {
            context = databaseContextProvider.Get();
            dbSet = context.Set<T>();
            this.updateMapping = updateMapping;
        }

        public async Task<Guid> Create(T entity, List<object> attach = null)
        {
            if (attach != null)
            {
                context.AttachRange(attach.ToArray());
            }

            await dbSet.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task CreateMany(IEnumerable<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }

        public async Task<bool> Delete(Guid id)
        {
            dbSet.Remove(dbSet.FirstOrDefault(f => f.Id == id));
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(T entity)
        {
            dbSet.Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteMany(IEnumerable<T> entities)
        {
            context.RemoveRange(entities);
            await context.SaveChangesAsync();
        }

        public Task SaveChangesAsync()
        {
            return context.SaveChangesAsync();
        }

        public async Task<bool> Update(T entity, List<string> includes = null, List<object> attach = null)
        {
            var exist = dbSet.Find(entity.Id);
            if (exist == null) throw new Exception("updateNoSuchEntity");

            if (attach != null)
            {
                context.AttachRange(attach.ToArray());
            }

            context.Entry(exist).CurrentValues.SetValues(updateMapping.Map(exist, entity));
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateWithoutMapping(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            dbSet.Update(entity);

            await context.SaveChangesAsync();
            return true;
        }
    }
}
