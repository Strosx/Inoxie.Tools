using Inoxie.Tools.ApiServices.Abstractions.Interfaces;

namespace Inoxie.Tools.ApiServices.Services;

internal class BaseDefaultWriteAuthorizationService<TInDto, TId> : IBaseWriteAuthorizationService<TInDto, TId>
{
    public Task<bool> AuthorizeAsync(TInDto dto) => Task.FromResult(true);

    public Task<bool> AuthorizeDeleteAsync(TId id) => Task.FromResult(true);
}