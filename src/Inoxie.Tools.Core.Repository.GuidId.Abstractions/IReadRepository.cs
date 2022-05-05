using Inoxie.Tools.Core.Repository.Abstractions;

namespace Inoxie.Tools.Core.Repository.GuidId.Abstractions;

public interface IReadRepository<TEntity> : IBaseReadRepository<TEntity, Guid> 
    where TEntity : IDataEntity
{}