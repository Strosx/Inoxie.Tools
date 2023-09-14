using Inoxie.Tools.Core.Repository.Abstractions;

namespace Inoxie.Tools.Core.Repository.GuidId.Abstractions;

/// <summary>
/// Represents an entity that uses a GUID as its ID.
/// </summary>
public interface IDataEntity : IBaseDataEntity<Guid>
{
}