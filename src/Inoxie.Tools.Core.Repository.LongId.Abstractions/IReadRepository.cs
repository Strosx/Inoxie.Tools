using Inoxie.Tools.Core.Repository.Abstractions;

namespace Inoxie.Tools.Core.Repository.LongId.Abstractions;

public interface IReadRepository<TEntity> : IBaseReadRepository<TEntity, long>
    where TEntity : IBaseDataEntity<long>
{
}