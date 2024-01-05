namespace Inoxie.Tools.ApiServices.Abstractions.Interfaces;

/// <summary>
/// Defines methods for post-processing read results. This service can be used, for example, for data anonymization.
/// Such operations should be performed at the application level rather than at the database level for better transparency and control.
/// </summary>
public interface IReadServicePostProcessor<TOutDto>
{
    /// <summary>
    /// Processes a single DTO after reading. This can be used for operations like data anonymization.
    /// </summary>
    virtual Task<TOutDto> ProcessAsync(TOutDto dto) => Task.FromResult(dto);

    /// <summary>
    /// Processes a collection of DTOs after reading. Suitable for batch processing.
    /// </summary>
    virtual async Task<List<TOutDto>> ProcessCollectionAsync(List<TOutDto> collection)
    {
        var tasks = collection.Select(ProcessAsync);
        var processed = await Task.WhenAll(tasks);
        return processed.ToList();
    }
}