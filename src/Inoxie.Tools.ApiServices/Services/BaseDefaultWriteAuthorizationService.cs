using Inoxie.Tools.ApiServices.Abstractions.Interfaces;

namespace Inoxie.Tools.ApiServices.Services;

/// <summary>
/// Default implementation of the <see cref="IBaseWriteAuthorizationService{TInDto, TId}"/> interface.
/// Serves as a placeholder to prevent default implementation absence errors and assumes all write operations are authorized.
/// </summary>
internal class BaseDefaultWriteAuthorizationService<TInDto, TId> : IBaseWriteAuthorizationService<TInDto, TId>
{
    public Task<bool> AuthorizeAsync(TInDto dto) => Task.FromResult(true);

    public Task<bool> AuthorizeDeleteAsync(TId id) => Task.FromResult(true);
}