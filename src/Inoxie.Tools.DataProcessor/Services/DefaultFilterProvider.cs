using Inoxie.Tools.DataProcessor.Abstractions.Interfaces;
using Inoxie.Tools.DataProcessor.Abstractions.Models;

namespace Inoxie.Tools.DataProcessor.Services
{
    internal class DefaultFilterProvider<TModel, TFilter> : IDataProcessorFilterProvider<TModel, TFilter>
        where TModel : class
        where TFilter : BaseFilterModel
    {
        public Func<TFilter, (IQueryable<TModel> query, int count)> GetFunc(IQueryable<TModel> queryable)
        {
            return (filterModel) =>
            {
                return new(queryable
                    .Skip(filterModel.Skip)
                    .Take(filterModel.Take), queryable.Count());
            };
        }
    }
}
