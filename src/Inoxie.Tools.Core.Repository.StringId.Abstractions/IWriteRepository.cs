using Inoxie.Tools.Core.Repository.Abstractions;

namespace Inoxie.Tools.Core.Repository.StringId.Abstractions;

public interface IWriteRepository<in TEntity> : IWriteRepository<TEntity, string> where TEntity : IDataEntity<string>
{
}