using Inoxie.Tools.Core.Repository.Abstractions;

namespace Inoxie.Tools.Core.Repository.StringId.Abstractions;

public interface IReadRepository<TEntity> : IBaseReadRepository<TEntity, string>
    where TEntity : IDataEntity
{
}