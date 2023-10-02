using Inoxie.Tools.Core.Repository.Abstractions;

namespace Inoxie.Tools.Core.Repository.StringId.Abstractions;

/// <summary>
/// Defines a data entity with a string identifier, extending the base data entity interface.
/// </summary>
public interface IDataEntity : IBaseDataEntity<string>
{
}