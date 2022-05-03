using Inoxie.Tools.Core.Repository.Abstractions;

namespace Inoxie.Tools.Core.Repository.StringId.Abstractions;

public interface IReadRepository<TEntity> : IReadRepository<TEntity, string>
    where TEntity : IDataEntity<string>
{
}