using Inoxie.Tools.Core.Repository.Abstractions;

namespace Inoxie.Tools.Core.Repository.GuidId.Abstractions;

public interface IWriteRepository<in TEntity> : IWriteRepository<TEntity, Guid> 
    where TEntity : IDataEntity<Guid>
{}