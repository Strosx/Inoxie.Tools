namespace Inoxie.Tools.Core.Repository.Abstractions;

public interface IBaseWriteRepository<in TEntity, TId> where TEntity : IBaseDataEntity<TId>
{
    [Obsolete("Use IDbSaveChanges.SaveChangesAsync instead")]
    Task SaveChangesAsync();

    Task<TId> CreateAsync(TEntity entity, List<object> attach = null, bool saveChanges = true);
    Task CreateManyAsync(IEnumerable<TEntity> entities, bool saveChanges = true);
    Task<bool> DeleteAsync(TId entity, bool saveChanges = true);
    Task<bool> DeleteAsync(TEntity entity, bool saveChanges = true);
    Task DeleteManyAsync(IEnumerable<TEntity> entities, bool saveChanges = true);
    Task<bool> UpdateAsync(TEntity entity, bool saveChanges = true);
}