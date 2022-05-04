using Inoxie.Tools.DataProcessor.Abstractions.Models;

namespace Inoxie.Tools.ApiServices.Abstractions.Interfaces;

public interface IBaseFilterReadService<TOutDto, in TFilter, in TId> : IBaseReadService<TOutDto, TId>
    where TOutDto : class
    where TFilter : BaseFilterModel
{
    Task<PagedDataResponse<TOutDto>> FilterAsync(TFilter filter);
    Task<TOutDto> GetByFilterFirstAsync(TFilter filter);
}