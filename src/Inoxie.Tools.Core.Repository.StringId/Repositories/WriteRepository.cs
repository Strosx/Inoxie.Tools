using Inoxie.Tools.Core.Repository.Abstractions;
using Inoxie.Tools.Core.Repository.Repositories;
using Inoxie.Tools.Core.Repository.StringId.Abstractions;

namespace Inoxie.Tools.Core.Repository.StringId.Repositories;

public class WriteRepository<TEntity> : WriteRepository<TEntity, string>, IWriteRepository<TEntity>
    where TEntity : class, IDataEntity
{
    public WriteRepository(IDatabaseContextProvider databaseContextProvider) : base(databaseContextProvider)
    {
    }
}