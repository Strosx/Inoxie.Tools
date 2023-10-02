using Inoxie.Tools.ApiServices.Abstractions.Interfaces;

namespace Inoxie.Tools.ApiServices.Services;

/// <summary>
/// Default implementation of the <see cref="IReadServicePostProcessor{TOutDto}"/> interface. 
/// Serves as a placeholder to prevent default implementation absence errors and does not apply any post-processing.
/// </summary>
internal class DefaultReadServicePostProcessor<TOutDto> : IReadServicePostProcessor<TOutDto>
{
    public Task<TOutDto> ProcessAsync(TOutDto dto) => Task.FromResult(dto);
    public Task<List<TOutDto>> ProcessCollectionAsync(List<TOutDto> collection) => Task.FromResult(collection);
}

