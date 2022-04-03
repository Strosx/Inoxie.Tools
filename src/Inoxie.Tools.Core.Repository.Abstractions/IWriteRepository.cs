namespace Inoxie.Tools.Core.Repository.Abstractions;

public interface IWriteRepository<T> where T : IDataEntity
{
    Task<Guid> CreateAsync(T entity, List<object> attach = null);
    Task CreateManyAsync(IEnumerable<T> entities);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(Guid entity);
    Task<bool> DeleteAsync(T entity);
    Task DeleteManyAsync(IEnumerable<T> entities);
    Task SaveChangesAsync();
}
