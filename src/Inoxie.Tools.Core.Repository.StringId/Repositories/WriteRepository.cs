using Inoxie.Tools.Core.Repository.Abstractions;
using Inoxie.Tools.Core.Repository.Repositories;
using Inoxie.Tools.Core.Repository.StringId.Abstractions;

namespace Inoxie.Tools.Core.Repository.StringId.Repositories;

public class WriteRepository<TEntity> : BaseWriteRepository<TEntity, string>, IWriteRepository<TEntity>
    where TEntity : class, IDataEntity
{
    public WriteRepository(IDatabaseContextProvider databaseContextProvider) : base(databaseContextProvider)
    {
    }

    public override Task<string> CreateAsync(TEntity entity, List<object>? attach = null)
    {
        entity.Id ??= Guid.NewGuid().ToString();
        return base.CreateAsync(entity, attach);
    }

    public override Task CreateManyAsync(IEnumerable<TEntity> entities)
    {
        var dataEntities = entities.Select(e =>
        {
            e.Id ??= Guid.NewGuid().ToString();
            return e;
        });

        return base.CreateManyAsync(dataEntities);
    }
}