using Inoxie.Tools.Core.Repository.Abstractions;

namespace Inoxie.Tools.Core.Repository.LongId.Abstractions;

public interface IReadRepository<TEntity> : IReadRepository<TEntity, long>
    where TEntity : IDataEntity<long>
{
}