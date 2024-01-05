namespace Inoxie.Tools.Core.Repository.Abstractions;

/// <summary>
/// Provides basic CRUD operations on a repository for entities with generic ID types.
/// </summary>
/// <typeparam name="TEntity">Type of the entity.</typeparam>
/// <typeparam name="TId">Type of the entity's identifier.</typeparam>
public interface IBaseWriteRepository<in TEntity, TId> where TEntity : IBaseDataEntity<TId>
{
    /// <summary>
    /// Creates a new entity in the repository.
    /// </summary>
    /// <param name="entity">The entity to create.</param>
    /// <param name="attach">
    /// List of related entities that already exist in the context.
    /// By attaching them, it informs EF that these entities are unmodified and shouldn't be recreated.
    /// </param>
    /// <param name="saveChanges">Indicates if changes should be saved immediately after creation.</param>
    /// <returns>The ID of the newly created entity.</returns>
    Task<TId> CreateAsync(TEntity entity, List<object> attach = null, bool saveChanges = true);
    /// <summary>
    /// Creates multiple entities in the repository.
    /// </summary>
    /// <param name="entities">The entities to create.</param>
    /// <param name="saveChanges">Indicates if changes should be saved immediately after creation.</param>
    Task CreateManyAsync(IEnumerable<TEntity> entities, bool saveChanges = true);
    /// <summary>
    /// Deletes an entity from the repository using its ID.
    /// </summary>
    /// <param name="entity">The ID of the entity to delete.</param>
    /// <param name="saveChanges">Indicates if changes should be saved immediately after deletion.</param>
    /// <returns>True if deletion was successful, false otherwise.</returns>
    Task<bool> DeleteAsync(TId entity, bool saveChanges = true);
    /// <summary>
    /// Deletes an entity from the repository.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    /// <param name="saveChanges">Indicates if changes should be saved immediately after deletion.</param>
    /// <returns>True if deletion was successful, false otherwise.</returns>
    Task<bool> DeleteAsync(TEntity entity, bool saveChanges = true);
    /// <summary>
    /// Deletes multiple entities from the repository.
    /// </summary>
    /// <param name="entities">The entities to delete.</param>
    /// <param name="saveChanges">Indicates if changes should be saved immediately after deletion.</param>
    Task DeleteManyAsync(IEnumerable<TEntity> entities, bool saveChanges = true);
    /// <summary>
    /// Updates an entity in the repository.
    /// </summary>
    /// <param name="entity">The entity with updated values.</param>
    /// <param name="saveChanges">Indicates if changes should be saved immediately after update.</param>
    /// <returns>True if update was successful.</returns>
    Task<bool> UpdateAsync(TEntity entity, bool saveChanges = true);

    /// <summary>
    /// Get last added id.
    /// </summary>
    /// <returns>Returns id of last added entity.</returns>
    TId GetLastAddedId();
}