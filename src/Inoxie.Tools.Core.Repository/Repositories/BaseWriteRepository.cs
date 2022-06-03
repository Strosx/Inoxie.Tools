using Inoxie.Tools.Core.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Inoxie.Tools.Core.Repository.Repositories;

public class BaseWriteRepository<TEntity, TId> : IBaseWriteRepository<TEntity, TId>
    where TEntity : class, IBaseDataEntity<TId>
{
    private readonly DbContext context;
    private readonly DbSet<TEntity> dbSet;

    public BaseWriteRepository(IDatabaseContextProvider databaseContextProvider)
    {
        context = databaseContextProvider.Get();
        dbSet = context.Set<TEntity>();
    }

    [Obsolete("Use IDbSaveChanges.SaveChangesAsync instead")]
    public Task SaveChangesAsync()
    {
        return context.SaveChangesAsync();
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

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        dbSet.Update(entity);

        await context.SaveChangesAsync();
        return true;
    }
}