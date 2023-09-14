using Inoxie.Tools.DataProcessor.Abstractions.Models;

namespace Inoxie.Tools.DataProcessor.Abstractions.Interfaces;

/// <summary>
/// Interface for providing filtering functions to the DataProcessor.
/// </summary>
/// <typeparam name="TModel">The type of data to be filtered.</typeparam>
/// <typeparam name="TFilter">The type of filter to be applied on data.</typeparam>
public interface IDataProcessorFilterProvider<TModel, TFilter>
    where TModel : class
    where TFilter : BaseFilterModel
{  
    /// <summary>
    /// Retrieves the filtering function based on the provided data source.
    /// </summary>
    /// <param name="queryable">The data source for filtering.</param>
    /// <returns>A function that takes a filter and returns the filtered query and count.</returns>
    Func<TFilter, (IQueryable<TModel> query, int count)> GetFunc(IQueryable<TModel> queryable);
}
