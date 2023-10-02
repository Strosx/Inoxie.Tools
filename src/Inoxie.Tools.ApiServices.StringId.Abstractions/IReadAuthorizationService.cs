using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.Core.Repository.StringId.Abstractions;

namespace Inoxie.Tools.ApiServices.StringId.Abstractions;

/// <summary>
/// Defines read authorization operations for entities using a string as an identifier.
/// </summary>
/// <remarks>
/// This interface specializes the <see cref="IBaseReadAuthorizationService{TEntity, TId}"/> for use cases where the identifier (`ID`) is a string. Implementations should handle authorization checks specifically tailored for string-based identifiers. It works in conjunction with the <see cref="IDataEntity"/> model to facilitate the authorization process.
/// </remarks>
public interface IReadAuthorizationService<TEntity> : IBaseReadAuthorizationService<TEntity, string>
    where TEntity : IDataEntity
{
}