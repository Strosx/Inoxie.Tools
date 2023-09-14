using Inoxie.Tools.DataProcessor.Abstractions.Interfaces;
using Inoxie.Tools.DataProcessor.Abstractions.Models;

namespace Inoxie.Tools.DataProcessor.Services;

/// <summary>
/// Default filter provider that applies simple pagination using Skip and Take parameters.
/// </summary>
/// <typeparam name="TModel">The type of the data model/entity.</typeparam>
/// <typeparam name="TFilter">The type of the filtering model.</typeparam>
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
