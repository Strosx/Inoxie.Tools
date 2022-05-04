using Inoxie.Tools.Core.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Inoxie.Tools.Core.Repository.Repositories;

public class WriteRepository<TEntity, TId> : IWriteRepository<TEntity, TId>
    where TEntity : class, IDataEntity<TId>
{
    private readonly DbContext context;
    private readonly DbSet<TEntity> dbSet;

    public WriteRepository(IDatabaseContextProvider databaseContextProvider)
    {
        context = databaseContextProvider.Get();
        dbSet = context.Set<TEntity>();
    }

    public virtual async Task<TId> CreateAsync(TEntity entity, List<object> attach = null)
    {
        if (attach != null)
        {
            context.AttachRange(attach.ToArray());
        }

        await dbSet.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public virtual async Task CreateManyAsync(IEnumerable<TEntity> entities)
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

    public async Task<bool> DeleteAsync(TEntity entity)
    {
        dbSet.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    public Task DeleteManyAsync(IEnumerable<TEntity> entities)
    {
        context.RemoveRange(entities);
        return context.SaveChangesAsync();
    }

    public Task SaveChangesAsync()
    {
        return context.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        dbSet.Update(entity);

        await context.SaveChangesAsync();
        return true;
    }
}