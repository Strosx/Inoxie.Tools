using Inoxie.Tools.DataProcessor.Abstractions.Models;

namespace Inoxie.Tools.DataProcessor.Abstractions.Interfaces
{
    public interface IDataProcessor<TModel, TFilter>
        where TModel : class
        where TFilter : BaseFilterModel
    {
        PagedDataResponse<TModel> Process(TFilter filter, IQueryable<TModel> queryable);
        QueryablePagedDataResponse<TModel> ProcessQueryable(TFilter filter, IQueryable<TModel> queryable);
    }

}
