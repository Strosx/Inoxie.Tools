using Inoxie.Tools.DataProcessor.Abstractions.Models;

namespace Inoxie.Tools.ApiServices.Abstractions.Interfaces;

/// <summary>
/// Defines methods for reading data with filtering capabilities.
/// </summary>
/// <remarks>
/// Extending <see cref="IBaseReadService{TOutDto, TId}"/>, this interface provides the ability to filter and page results with the help of <see cref="IDataProcessor{TEntity, TFilter}"/>. The underlying implementation fetches data using <see cref="IBaseReadRepository{TEntity, TId}"/>, applies filtering and then maps the results using AutoMapper. The final results undergo post-processing via <see cref="IReadServicePostProcessor{TOutDto}"/>.
/// </remarks>
public interface IBaseFilterReadService<TOutDto, in TFilter, in TId> : IBaseReadService<TOutDto, TId>
    where TOutDto : class
    where TFilter : BaseFilterModel
{
    /// <summary>
    /// Applies filtering on the records and retrieves a paged data response.
    /// </summary>
    Task<PagedDataResponse<TOutDto>> FilterAsync(TFilter filter);
    
    /// <summary>
    /// Retrieves the first record based on the applied filter.
    /// </summary>
    Task<TOutDto> GetByFilterFirstAsync(TFilter filter);
}