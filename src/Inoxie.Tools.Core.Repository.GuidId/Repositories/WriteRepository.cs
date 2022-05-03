using Inoxie.Tools.Core.Repository.Abstractions;
using Inoxie.Tools.Core.Repository.GuidId.Abstractions;
using Inoxie.Tools.Core.Repository.Repositories;

namespace Inoxie.Tools.Core.Repository.GuidId.Repositories;

internal class WriteRepository<TEntity> : WriteRepository<TEntity, Guid>, IWriteRepository<TEntity>
    where TEntity : class, IDataEntity<Guid>
{
    public WriteRepository(IDatabaseContextProvider databaseContextProvider) : base(databaseContextProvider)
    {
    }
}