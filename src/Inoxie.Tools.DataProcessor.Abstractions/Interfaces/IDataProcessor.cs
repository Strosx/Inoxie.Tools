using Inoxie.Tools.DataProcessor.Abstractions.Models;

namespace Inoxie.Tools.DataProcessor.Abstractions.Interfaces;

/// <summary>
/// Interface for processing data with pagination and filtering.
/// </summary>
/// <typeparam name="TModel">The type of data to be processed.</typeparam>
/// <typeparam name="TFilter">The type of filter to be applied on data.</typeparam>
public interface IDataProcessor<TModel, TFilter>
    where TModel : class
    where TFilter : BaseFilterModel
{
    /// <summary>
    /// Processes the given data source with pagination and filtering.
    /// </summary>
    /// <param name="filter">The filter to be applied on data.</param>
    /// <param name="queryable">The data source to be processed.</param>
    /// <returns>Paged response with the processed data.</returns>
    PagedDataResponse<TModel> Process(TFilter filter, IQueryable<TModel> queryable);
    
    /// <summary>
    /// Processes the given data source with pagination and returns as IQueryable.
    /// </summary>
    /// <param name="filter">The filter to be applied on data.</param>
    /// <param name="queryable">The data source to be processed.</param>
    /// <returns>Paged response with the processed data as IQueryable.</returns>
    QueryablePagedDataResponse<TModel> ProcessQueryable(TFilter filter, IQueryable<TModel> queryable);
}

