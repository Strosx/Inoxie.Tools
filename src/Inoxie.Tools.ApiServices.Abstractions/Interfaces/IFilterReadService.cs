using Inoxie.Tools.DataProcessor.Abstractions.Models;

namespace Inoxie.Tools.ApiServices.Abstractions.Interfaces;

public interface IFilterReadService<TOutDto, TFilter> : IReadService<TOutDto>
    where TOutDto : class
    where TFilter : BaseFilterModel
{
    Task<TOutDto> GetByFilterFirstAsync(TFilter filter);
    Task<PagedDataResponse<TOutDto>> FilterAsync(TFilter filter);
}
