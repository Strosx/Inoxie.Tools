using Inoxie.Tools.ApiServices.Abstractions.Interfaces;

namespace Inoxie.Tools.ApiServices.GuidId.Abstractions;

public interface IReadService<TOutDto> : IBaseReadService<TOutDto, Guid>
{}