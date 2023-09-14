using Inoxie.Tools.Core.Repository.Abstractions;

namespace Inoxie.Tools.Core.Repository.LongId.Abstractions;

/// <summary>
/// Provides write capabilities for entities with long identifiers.
/// </summary>
/// <typeparam name="TEntity">The type of the entity. Must implement the IDataEntity interface.</typeparam>
public interface IWriteRepository<in TEntity> : IBaseWriteRepository<TEntity, long>
    where TEntity : IDataEntity
{
}