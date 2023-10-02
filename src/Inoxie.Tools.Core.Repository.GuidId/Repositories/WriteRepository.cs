using Inoxie.Tools.Core.Repository.Abstractions;
using Inoxie.Tools.Core.Repository.GuidId.Abstractions;
using Inoxie.Tools.Core.Repository.Repositories;

namespace Inoxie.Tools.Core.Repository.GuidId.Repositories;

/// <summary>
/// Provides write operations for entities that use GUIDs as their primary identifiers.
/// </summary>
/// <typeparam name="TEntity">The type of the entity. Must implement the IDataEntity interface.</typeparam>
public class WriteRepository<TEntity> : BaseWriteRepository<TEntity, Guid>, IWriteRepository<TEntity>
    where TEntity : class, IDataEntity
{
    public WriteRepository(IDatabaseContextProvider databaseContextProvider) : base(databaseContextProvider)
    {
    }
}