using Inoxie.Tools.DataProcessor.Abstractions.Interfaces;
using Inoxie.Tools.DataProcessor.Abstractions.Models;

namespace Inoxie.Tools.DataProcessor.Services
{
    internal class DataProcessorImplementation<TModel, TFilter> : IDataProcessor<TModel, TFilter>
        where TModel : class
        where TFilter : BaseFilterModel
    {
        private readonly IDataProcessorFilterProvider<TModel, TFilter> dataProcessorFilterProvider;

        public DataProcessorImplementation(
            IDataProcessorFilterProvider<TModel, TFilter> dataProcessorFilterProvider)
        {
            this.dataProcessorFilterProvider = dataProcessorFilterProvider;
        }

        public PagedDataResponse<TModel> Process(TFilter filter, IQueryable<TModel> queryable)
        {
            Func<TFilter, (IQueryable<TModel> query, int count)> filterData = dataProcessorFilterProvider.GetFunc(queryable);

            var (query, count) = filterData(filter);

            var result = new PagedDataResponse<TModel>
            {
                Collection = query,
                Total = count
            };
            return result;
        }

        public QueryablePagedDataResponse<TModel> ProcessQueryable(TFilter filter, IQueryable<TModel> queryable)
        {
            Func<TFilter, (IQueryable<TModel> query, int count)> filterData = dataProcessorFilterProvider.GetFunc(queryable);

            var (query, count) = filterData(filter);

            var result = new QueryablePagedDataResponse<TModel>
            {
                Collection = query,
                Total = count
            };
            return result;
        }
    }
}
