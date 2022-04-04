using Inoxie.Tools.ApiServices.Abstractions.Interfaces;

namespace Inoxie.Tools.ApiServices.Services;

internal class DefaultWriteAuthorizationService<TInDto> : IWriteAuthorizationService<TInDto>
{
    public Task<bool> AuthorizeAsync(TInDto dto) => Task.FromResult(true);

    public Task<bool> AuthorizeDeleteAsync(Guid id) => Task.FromResult(true);

}
