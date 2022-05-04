using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.DataProcessor.Abstractions.Models;

namespace Inoxie.Tools.ApiServices.StringId.Abstractions;

public interface IFilterReadService<TOutDto, in TFilter> : IBaseFilterReadService<TOutDto, TFilter, string>, IReadService<TOutDto>
    where TOutDto : class
    where TFilter : BaseFilterModel
{
}