using Inoxie.Tools.Core.Repository.Abstractions;
using Inoxie.Tools.Core.Repository.LongId.Abstractions;
using Inoxie.Tools.Core.Repository.Repositories;

namespace Inoxie.Tools.Core.Repository.LongId.Repositories;

public class ReadRepository<TEntity> : ReadRepository<TEntity, long>, IReadRepository<TEntity>
    where TEntity : class, IDataEntity
{
    public ReadRepository(IDatabaseContextProvider databaseContextProvider) : base(databaseContextProvider)
    {
    }
}