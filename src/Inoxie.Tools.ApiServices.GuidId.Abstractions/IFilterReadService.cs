using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.DataProcessor.Abstractions.Models;

namespace Inoxie.Tools.ApiServices.GuidId.Abstractions;

public interface IFilterReadService<TOutDto, in TFilter> : IFilterReadService<TOutDto, TFilter, Guid>, IReadService<TOutDto>
    where TOutDto : class
    where TFilter : BaseFilterModel
{
}