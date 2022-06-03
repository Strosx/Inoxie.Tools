namespace Inoxie.Tools.Core.Repository.Abstractions;

public interface IBaseWriteRepository<in TEntity, TId> where TEntity : IBaseDataEntity<TId>
{
    [Obsolete("Use IDbSaveChanges.SaveChangesAsync instead")]
    Task SaveChangesAsync();

    Task<TId> CreateAsync(TEntity entity, List<object> attach = null);
    Task CreateManyAsync(IEnumerable<TEntity> entities);
    Task<bool> DeleteAsync(TId entity);
    Task<bool> DeleteAsync(TEntity entity);
    Task DeleteManyAsync(IEnumerable<TEntity> entities);
    Task<bool> UpdateAsync(TEntity entity);
}