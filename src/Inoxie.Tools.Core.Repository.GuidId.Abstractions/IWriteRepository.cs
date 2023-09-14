using Inoxie.Tools.Core.Repository.Abstractions;

namespace Inoxie.Tools.Core.Repository.GuidId.Abstractions;

/// <summary>
/// Provides a contract for write operations for entities using GUIDs as IDs.
/// </summary>
/// <typeparam name="TEntity">The type of the entity. Must implement the IDataEntity interface.</typeparam>
public interface IWriteRepository<in TEntity> : IBaseWriteRepository<TEntity, Guid> 
    where TEntity : IDataEntity
{}