using Inoxie.Tools.Core.Repository.Abstractions;

namespace Inoxie.Tools.Core.Repository.StringId.Abstractions;

public interface IWriteRepository<in TEntity> : IBaseWriteRepository<TEntity, string>
    where TEntity : IBaseDataEntity<string>
{
}