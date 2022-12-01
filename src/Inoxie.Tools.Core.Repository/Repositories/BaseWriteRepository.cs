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

    public virtual async Task<TId> CreateAsync(TEntity entity, List<object> attach = null, bool saveChanges = true)
    {
        if (attach != null)
        {
            context.AttachRange(attach.ToArray());
        }

        await dbSet.AddAsync(entity);
        if (saveChanges)
        {
            await context.SaveChangesAsync();
        }
        return entity.Id;
    }

    public virtual async Task CreateManyAsync(IEnumerable<TEntity> entities, bool saveChanges = true)
    {
        await dbSet.AddRangeAsync(entities);
        if (saveChanges)
        {
            await context.SaveChangesAsync();
        }
    }

    public async Task<bool> DeleteAsync(TId id, bool saveChanges = true)
    {
        var entity = dbSet.FirstOrDefault(f => Equals(f.Id, id));
        if (entity == null)
        {
            return false;
        }

        dbSet.Remove(entity);
        if (saveChanges)
        {
            await context.SaveChangesAsync();
        }
        return true;
    }

    public async Task<bool> DeleteAsync(TEntity entity, bool saveChanges = true)
    {
        dbSet.Remove(entity);
        if (saveChanges)
        {
            await context.SaveChangesAsync();
        }
        return true;
    }

    public async Task DeleteManyAsync(IEnumerable<TEntity> entities, bool saveChanges = true)
    {
        context.RemoveRange(entities);
        if (saveChanges)
        {
            await context.SaveChangesAsync();
        }
    }

    public async Task<bool> UpdateAsync(TEntity entity, bool saveChanges = true)
    {
        context.Entry(entity).State = EntityState.Modified;
        dbSet.Update(entity);

        if (saveChanges)
        {
            await context.SaveChangesAsync();
        }
        return true;
    }
}