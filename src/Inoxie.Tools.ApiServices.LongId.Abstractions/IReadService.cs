using Inoxie.Tools.ApiServices.Abstractions.Interfaces;

namespace Inoxie.Tools.ApiServices.LongId.Abstractions;

public interface IReadService<TOutDto> : IBaseReadService<TOutDto, long>
{
}