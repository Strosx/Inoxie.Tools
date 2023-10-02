using Inoxie.Tools.Core.Repository.Abstractions;
using Inoxie.Tools.Core.Repository.Repositories;
using Inoxie.Tools.Core.Repository.StringId.Abstractions;

namespace Inoxie.Tools.Core.Repository.StringId.Repositories;

/// <summary>
/// Provides a concrete implementation for the IWriteRepository tailored for entities with a string ID.
/// This implementation ensures that if an ID is not provided for the entity during its creation, 
/// it automatically generates a GUID and converts it to a string format.
/// </summary>
/// <typeparam name="TEntity">Type of the entity to work with.</typeparam>
public class WriteRepository<TEntity> : BaseWriteRepository<TEntity, string>, IWriteRepository<TEntity>
    where TEntity : class, IDataEntity
{
    public WriteRepository(IDatabaseContextProvider databaseContextProvider) : base(databaseContextProvider)
    {
    }

    public override Task<string> CreateAsync(TEntity entity, List<object>? attach = null, bool saveChanges = true)
    {
        entity.Id = string.IsNullOrWhiteSpace(entity.Id) ? Guid.NewGuid().ToString() : entity.Id;
        return base.CreateAsync(entity, attach, saveChanges);
    }

    public override Task CreateManyAsync(IEnumerable<TEntity> entities, bool saveChanges = true)
    {
        var dataEntities = entities.Select(entity =>
        {
            entity.Id = string.IsNullOrWhiteSpace(entity.Id) ? Guid.NewGuid().ToString() : entity.Id;
            return entity;
        });

        return base.CreateManyAsync(dataEntities, saveChanges);
    }
}