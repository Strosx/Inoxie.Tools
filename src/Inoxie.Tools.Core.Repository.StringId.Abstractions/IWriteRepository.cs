using Inoxie.Tools.Core.Repository.Abstractions;

namespace Inoxie.Tools.Core.Repository.StringId.Abstractions;

/// <summary>
/// Represents a data entity specifically designed to have a string ID.
/// </summary>
public interface IWriteRepository<in TEntity> : IBaseWriteRepository<TEntity, string>
    where TEntity : IDataEntity
{
}