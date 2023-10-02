using Inoxie.Tools.Core.Repository.Abstractions;
using Inoxie.Tools.Core.Repository.GuidId.Abstractions;
using Inoxie.Tools.Core.Repository.Repositories;

namespace Inoxie.Tools.Core.Repository.GuidId.Repositories;

/// <summary>
/// Provides read operations for entities that use GUIDs as their primary identifiers.
/// </summary>
/// <typeparam name="TEntity">The type of the entity. Must implement the IDataEntity interface.</typeparam>
public class ReadRepository<TEntity> : BaseReadRepository<TEntity, Guid>, IReadRepository<TEntity>
    where TEntity : class, IDataEntity
{
    public ReadRepository(IDatabaseContextProvider databaseContextProvider) : base(databaseContextProvider)
    {
    }
}