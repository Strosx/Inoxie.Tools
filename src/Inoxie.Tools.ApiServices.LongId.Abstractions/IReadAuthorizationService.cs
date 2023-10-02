using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.Core.Repository.LongId.Abstractions;

namespace Inoxie.Tools.ApiServices.LongId.Abstractions;

/// <summary>
/// Defines read authorization operations for entities using a long integer as an identifier.
/// </summary>
/// <remarks>
/// This interface specializes the <see cref="IBaseReadAuthorizationService{TEntity, TId}"/> for scenarios where the identifier (`ID`) is a long integer. Implementations should handle authorization checks specifically tailored for long integer identifiers. This interface collaborates with the <see cref="IDataEntity"/> model to streamline the authorization procedure.
/// </remarks>
public interface IReadAuthorizationService<TEntity> : IBaseReadAuthorizationService<TEntity, long>
    where TEntity : IDataEntity
{
}