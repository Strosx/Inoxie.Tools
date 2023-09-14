using Inoxie.Tools.Core.Repository.Abstractions;
using Inoxie.Tools.Core.Repository.LongId.Abstractions;
using Inoxie.Tools.Core.Repository.Repositories;

namespace Inoxie.Tools.Core.Repository.LongId.Repositories;

/// <summary>
/// Implementation of the write repository for entities with long IDs.
/// </summary>
/// <typeparam name="TEntity">The type of the entity. Must implement the IDataEntity interface.</typeparam>
public class WriteRepository<TEntity> : BaseWriteRepository<TEntity, long>, IWriteRepository<TEntity>
    where TEntity : class, IDataEntity
{
    public WriteRepository(IDatabaseContextProvider databaseContextProvider) : base(databaseContextProvider)
    {
    }
}