namespace Inoxie.Tools.Core.Repository.Abstractions;

public interface IWriteRepository<in T, TId> where T : IDataEntity<TId>
{
    Task<TId> CreateAsync(T entity, List<object> attach = null);
    Task CreateManyAsync(IEnumerable<T> entities);
    Task<bool> DeleteAsync(TId entity);
    Task<bool> DeleteAsync(T entity);
    Task DeleteManyAsync(IEnumerable<T> entities);
    Task SaveChangesAsync();
    Task<bool> UpdateAsync(T entity);
}