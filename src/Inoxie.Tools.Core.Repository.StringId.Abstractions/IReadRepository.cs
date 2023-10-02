using Inoxie.Tools.Core.Repository.Abstractions;

namespace Inoxie.Tools.Core.Repository.StringId.Abstractions;

/// <summary>
/// Defines a read-only repository contract specifically tailored for entities with a string as their ID.
/// </summary>
/// <typeparam name="TEntity">Type of the entity to work with.</typeparam>
public interface IReadRepository<TEntity> : IBaseReadRepository<TEntity, string>
    where TEntity : IDataEntity
{
}