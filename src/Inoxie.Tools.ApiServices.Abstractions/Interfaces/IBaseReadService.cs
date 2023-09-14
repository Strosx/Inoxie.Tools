namespace Inoxie.Tools.ApiServices.Abstractions.Interfaces;

/// <summary>
/// Defines basic read operations for a given DTO and ID type.
/// </summary>
/// <remarks>
/// The default implementation uses <see cref="IBaseReadRepository{TEntity, TId}"/> for data access and applies authorization rules using <see cref="IBaseReadAuthorizationService{TEntity, TId}"/>. The results are post-processed with <see cref="IReadServicePostProcessor{TOutDto}"/> before returning.
/// </remarks>
public interface IBaseReadService<TOutDto, in TId>
{
    /// <summary>
    /// Retrieves all records.
    /// </summary>
    Task<List<TOutDto>> GetAllAsync();
    
    /// <summary>
    /// Retrieves a specific record based on the provided ID.
    /// </summary>
    Task<TOutDto> GetAsync(TId id);
}
