using Inoxie.Tools.Core.Repository.Abstractions;
using Inoxie.Tools.Core.Repository.Repositories;
using Inoxie.Tools.Core.Repository.StringId.Abstractions;

namespace Inoxie.Tools.Core.Repository.StringId.Repositories;

/// <summary>
/// Provides an implementation of a read-only repository specifically tailored for entities with a string-based ID.
/// This class encapsulates the common patterns of reading data from entities identified by string IDs and is backed by the functionality provided by the BaseReadRepository.
/// Developers can use this class directly for reading operations on entities with string IDs or as a foundation for more specialized string-based ID repositories.
/// </summary>
/// <typeparam name="TEntity">The type of the entity the repository operates on.</typeparam>
public class ReadRepository<TEntity> : BaseReadRepository<TEntity, string>, IReadRepository<TEntity>
    where TEntity : class, IDataEntity
{
    public ReadRepository(IDatabaseContextProvider databaseContextProvider) : base(databaseContextProvider)
    {
    }
}