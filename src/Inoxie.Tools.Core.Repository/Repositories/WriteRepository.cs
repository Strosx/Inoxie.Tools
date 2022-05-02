using Inoxie.Tools.Core.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Inoxie.Tools.Core.Repository.Repositories;

public class WriteRepository<T, TId> : IWriteRepository<T, TId>
    where T : class, IDataEntity<TId>
{
    private readonly DbContext context;
    private readonly DbSet<T> dbSet;

    public WriteRepository(IDatabaseContextProvider databaseContextProvider)
    {
        context = databaseContextProvider.Get();
        dbSet = context.Set<T>();
    }

    public async Task<TId> CreateAsync(T entity, List<object> attach = null)
    {
        if (attach != null)
        {
            context.AttachRange(attach.ToArray());
        }

        await dbSet.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task CreateManyAsync(IEnumerable<T> entities)
    {
        await dbSet.AddRangeAsync(entities);
        await context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(TId id)
    {
        var entity = dbSet.FirstOrDefault(f => Equals(f.Id, id));
        if (entity == null)
        {
            return false;
        }

        dbSet.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(T entity)
    {
        dbSet.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    public Task DeleteManyAsync(IEnumerable<T> entities)
    {
        context.RemoveRange(entities);
        return context.SaveChangesAsync();
    }

    public Task SaveChangesAsync()
    {
        return context.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        dbSet.Update(entity);

        await context.SaveChangesAsync();
        return true;
    }
}