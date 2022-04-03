using Inoxie.Tools.DataProcessor.Abstractions.Interfaces;
using Inoxie.Tools.DataProcessor.Abstractions.Models;

namespace Inoxie.Tools.DataProcessor.Services;

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
