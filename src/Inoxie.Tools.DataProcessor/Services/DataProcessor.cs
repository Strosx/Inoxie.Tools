using Inoxie.Tools.DataProcessor.Abstractions.Interfaces;
using Inoxie.Tools.DataProcessor.Abstractions.Models;

namespace Inoxie.Tools.DataProcessor.Services;

/// <summary>
/// A data processor service responsible for paginating and optionally filtering database entities.
/// </summary>
/// <typeparam name="TModel">The type of the data model/entity.</typeparam>
/// <typeparam name="TFilter">The type of the filtering model.</typeparam>
internal class DataProcessor<TModel, TFilter> : IDataProcessor<TModel, TFilter>
    where TModel : class
    where TFilter : BaseFilterModel
{
    private readonly IDataProcessorFilterProvider<TModel, TFilter> dataProcessorFilterProvider;

    public DataProcessor(IDataProcessorFilterProvider<TModel, TFilter> dataProcessorFilterProvider)
    {
        this.dataProcessorFilterProvider = dataProcessorFilterProvider;
    }

    public PagedDataResponse<TModel> Process(TFilter filter, IQueryable<TModel> queryable)
    {
        Func<TFilter, (IQueryable<TModel> query, int count)> filterData = dataProcessorFilterProvider.GetFunc(queryable);

        var (query, count) = filterData(filter);

        return new PagedDataResponse<TModel>
        {
            Collection = query,
            Total = count
        };
    }

    public QueryablePagedDataResponse<TModel> ProcessQueryable(TFilter filter, IQueryable<TModel> queryable)
    {
        Func<TFilter, (IQueryable<TModel> query, int count)> filterData = dataProcessorFilterProvider.GetFunc(queryable);

        var (query, count) = filterData(filter);

        return new QueryablePagedDataResponse<TModel>
        {
            Collection = query,
            Total = count
        };
    }
}
