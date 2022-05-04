using Inoxie.Tools.Core.Repository.Abstractions;

namespace Inoxie.Tools.Core.Repository.GuidId.Abstractions;

public interface IWriteRepository<in TEntity> : IBaseWriteRepository<TEntity, Guid> 
    where TEntity : IBaseDataEntity<Guid>
{}