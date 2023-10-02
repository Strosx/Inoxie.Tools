namespace Inoxie.Tools.ApiServices.Abstractions.Interfaces;

/// <summary>
/// Defines basic write operations for a given DTO and ID type.
/// </summary>
/// <remarks>
/// The default implementation leverages both <see cref="IBaseReadRepository{TEntity, TId}"/> and <see cref="IBaseWriteRepository{TEntity, TId}"/> for data access. Authorization is handled by <see cref="IBaseWriteAuthorizationService{TInDto, TId}"/> to ensure security. 
/// For updating entities, the implementation uses the `MapPropertiesFrom` utility method for mapping properties.
/// </remarks>
public interface IBaseWriteService<TInDto, TId>
{
    /// <summary>
    /// Creates a record based on the provided DTO.
    /// </summary>
    Task<TId> CreateAsync(TInDto inDto);
    
    /// <summary>
    /// Creates multiple records based on the provided list of DTOs.
    /// </summary>
    Task CreateManyAsync(List<TInDto> inDtos);
    
    /// <summary>
    /// Deletes a record based on the provided ID.
    /// </summary>
    Task DeleteAsync(TId id);
    
    /// <summary>
    /// Updates a record based on the provided DTO and ID.
    /// </summary>
    Task UpdateAsync(TInDto inDto, TId id);
}