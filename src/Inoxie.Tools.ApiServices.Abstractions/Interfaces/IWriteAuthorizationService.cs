namespace Inoxie.Tools.ApiServices.Abstractions.Interfaces;

public interface IWriteAuthorizationService<TInDto>
{
    Task<bool> AuthorizeAsync(TInDto dto);
    async Task<bool> AuthorizeAsync(List<TInDto> collection)
    {
        var tasks = collection.Select(AuthorizeAsync);
        var processed = await Task.WhenAll(tasks);
        return processed.All(x => x);
    }

    Task<bool> AuthorizeDeleteAsync(Guid id);
}

