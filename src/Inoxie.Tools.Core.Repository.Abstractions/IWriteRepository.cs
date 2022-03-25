namespace Inoxie.Tools.Core.Repository.Abstractions
{
    public interface IWriteRepository<T> where T : IDataEntity
    {
        Task<Guid> Create(T entity, List<object> attach = null);
        Task CreateMany(IEnumerable<T> entities);
        Task<bool> Update(T entity, List<string> includes = null, List<object> attach = null);
        Task<bool> UpdateWithoutMapping(T entity);
        Task<bool> Delete(Guid entity);
        Task<bool> Delete(T entity);
        Task DeleteMany(IEnumerable<T> entities);
        Task SaveChangesAsync();
    }
}
