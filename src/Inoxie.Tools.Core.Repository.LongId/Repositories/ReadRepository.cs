using Inoxie.Tools.Core.Repository.Abstractions;
using Inoxie.Tools.Core.Repository.LongId.Abstractions;
using Inoxie.Tools.Core.Repository.Repositories;

namespace Inoxie.Tools.Core.Repository.LongId.Repositories;

/// <summary>
/// Implementation of the read repository for entities with long IDs.
/// </summary>
/// <typeparam name="TEntity">The type of the entity. Must implement the IDataEntity interface.</typeparam>
public class ReadRepository<TEntity> : BaseReadRepository<TEntity, long>, IReadRepository<TEntity>
    where TEntity : class, IDataEntity
{
    public ReadRepository(IDatabaseContextProvider databaseContextProvider) : base(databaseContextProvider)
    {
    }
}