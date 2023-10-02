using Inoxie.Tools.Core.Repository.Abstractions;
using System.Linq.Expressions;

namespace Inoxie.Tools.ApiServices.Abstractions.Interfaces;

/// <summary>
/// Defines methods for reading authorization for a data entity.
/// </summary>
/// <remarks>
/// Implementing classes should only contain authorization logic to determine if a specific account has access to a given resource.
/// In the default implementation, these methods are executed on IQueryable as the first operations.
/// </remarks>
public interface IBaseReadAuthorizationService<TEntity, TId>
    where TEntity : IBaseDataEntity<TId>
{
    /// <summary>
    /// Gets an expression defining which entities are authorized for reading.
    /// </summary>
    /// <remarks>
    /// This method returns an expression to filter out unauthorized entities at the IQueryable level.
    /// </remarks>
    Task<Expression<Func<TEntity, bool>>> Get();
}