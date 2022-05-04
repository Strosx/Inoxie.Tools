namespace Inoxie.Tools.Core.Repository.Abstractions;

public interface IWriteRepository<in TEntity, TId> where TEntity : IDataEntity<TId>
{
    Task<TId> CreateAsync(TEntity entity, List<object> attach = null);
    Task CreateManyAsync(IEnumerable<TEntity> entities);
    Task<bool> DeleteAsync(TId entity);
    Task<bool> DeleteAsync(TEntity entity);
    Task DeleteManyAsync(IEnumerable<TEntity> entities);
    Task SaveChangesAsync();
    Task<bool> UpdateAsync(TEntity entity);
}