using Inoxie.Tools.DataProcessor.Abstractions.Models;

namespace Inoxie.Tools.DataProcessor.Abstractions.Interfaces;

public interface IDataProcessorFilterProvider<TModel, TFilter>
    where TModel : class
    where TFilter : BaseFilterModel
{
    Func<TFilter, (IQueryable<TModel> query, int count)> GetFunc(IQueryable<TModel> queryable);
}
