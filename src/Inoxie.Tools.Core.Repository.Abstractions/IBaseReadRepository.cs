using System.Linq.Expressions;

namespace Inoxie.Tools.Core.Repository.Abstractions;

/// <summary>
/// Provides a set of methods for querying entities of a specified type with a specified identifier type.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
/// <typeparam name="TId">The type of the entity's identifier.</typeparam>
public interface IBaseReadRepository<TEntity, in TId> where TEntity : IBaseDataEntity<TId>
{
    /// <summary>
    /// Asynchronously retrieves an entity by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the entity to be retrieved.</param>
    /// <param name="asTracking">If set to <c>true</c>, the entity is retrieved as a tracking entity; otherwise, as a non-tracking entity. The default value is <c>false</c>.</param>
    /// <returns>The entity that matches the specified identifier or null if no entity is found.</returns>
    Task<TEntity> GetAsync(TId id, bool asTracking = false);

    /// <summary>
    /// Asynchronously retrieves a list of entities that match the specified predicate.
    /// </summary>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="asTracking">If set to <c>true</c>, the entities are retrieved as tracking entities; otherwise, as non-tracking entities. The default value is <c>false</c>.</param>
    /// <returns>A list of entities that match the specified predicate.</returns>
    Task<List<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate, bool asTracking = false);

    /// <summary>
    /// Asynchronously retrieves the first entity that matches the specified predicate or a default value if no such entity is found.
    /// </summary>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="asTracking">If set to <c>true</c>, the entity is retrieved as a tracking entity; otherwise, as a non-tracking entity. The default value is <c>false</c>.</param>
    /// <returns>The first entity that matches the specified predicate or a default value if no such entity is found.</returns>
    Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool asTracking = false);

    /// <summary>
    /// Provides a queryable interface for the entities of the specified type.
    /// </summary>
    /// <param name="asTracking">If set to <c>true</c>, the entities are retrieved as tracking entities; otherwise, as non-tracking entities. The default value is <c>false</c>.</param>
    /// <returns>A queryable interface for the entities of the specified type.</returns>
    IQueryable<TEntity> AsQueryable(bool asTracking = false);
}
