using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.Core.Repository.GuidId.Abstractions;

namespace Inoxie.Tools.ApiServices.GuidId.Abstractions;

/// <summary>
/// Defines read authorization operations for entities using a GUID (Globally Unique Identifier) as an identifier.
/// </summary>
/// <remarks>
/// This interface specializes the <see cref="IBaseReadAuthorizationService{TEntity, TId}"/> for scenarios where the identifier (`ID`) is a GUID. Implementations should handle authorization checks that are designed for GUID-based identifiers. It works in tandem with the <see cref="IDataEntity"/> structure to facilitate the authorization operations.
/// </remarks>
public interface IReadAuthorizationService<TEntity> : IBaseReadAuthorizationService<TEntity, Guid>
    where TEntity : IDataEntity
{
}