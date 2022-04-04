namespace Inoxie.Tools.ApiServices.Abstractions.Interfaces;

public interface IReadServicePostProcessor<TOutDto>
{
    Task<TOutDto> ProcessAsync(TOutDto dto);
    async Task<List<TOutDto>> ProcessCollectionAsync(List<TOutDto> collection)
    {
        var tasks = collection.Select(ProcessAsync);
        var processed = await Task.WhenAll(tasks);
        return processed.ToList();
    }
}