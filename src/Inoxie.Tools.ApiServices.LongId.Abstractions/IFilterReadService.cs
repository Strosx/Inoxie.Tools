using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.DataProcessor.Abstractions.Models;

namespace Inoxie.Tools.ApiServices.LongId.Abstractions;

public interface IFilterReadService<TOutDto, in TFilter> : IBaseFilterReadService<TOutDto, TFilter, long>, IReadService<TOutDto>
    where TOutDto : class
    where TFilter : BaseFilterModel
{}