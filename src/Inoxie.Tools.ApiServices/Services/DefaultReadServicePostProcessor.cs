using Inoxie.Tools.ApiServices.Abstractions.Interfaces;

namespace Inoxie.Tools.ApiServices.Services;

internal class DefaultReadServicePostProcessor<TOutDto> : IReadServicePostProcessor<TOutDto>
{
    public Task<TOutDto> ProcessAsync(TOutDto dto) => Task.FromResult(dto);
    public Task<List<TOutDto>> ProcessCollectionAsync(List<TOutDto> collection) => Task.FromResult(collection);
}

