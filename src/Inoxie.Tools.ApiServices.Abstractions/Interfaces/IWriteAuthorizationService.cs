namespace Inoxie.Tools.ApiServices.Abstractions.Interfaces;

public interface IWriteAuthorizationService<TInDto, in TId>
{
    Task<bool> AuthorizeAsync(TInDto dto);
    async Task<bool> AuthorizeAsync(List<TInDto> collection)
    {
        var tasks = collection.Select(AuthorizeAsync);
        var processed = await Task.WhenAll(tasks);
        return processed.All(x => x);
    }

    Task<bool> AuthorizeDeleteAsync(TId id);
}

