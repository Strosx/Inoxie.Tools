using Inoxie.Tools.DataProcessor.Abstractions.Models;

namespace Inoxie.Tools.ApiServices.Abstractions.Interfaces;

public interface IFilterReadService<TOutDto, in TFilter, in TId> : IReadService<TOutDto, TId>
    where TOutDto : class
    where TFilter : BaseFilterModel
{
    Task<PagedDataResponse<TOutDto>> FilterAsync(TFilter filter);
    Task<TOutDto> GetByFilterFirstAsync(TFilter filter);
}