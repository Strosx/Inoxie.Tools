using Inoxie.Tools.Core.Repository.Abstractions;

namespace Inoxie.Tools.Core.Repository.LongId.Abstractions;

public interface IWriteRepository<in TEntity> : IBaseWriteRepository<TEntity, long>
    where TEntity : IDataEntity
{
}