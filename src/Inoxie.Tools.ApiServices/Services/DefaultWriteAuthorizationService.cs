using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.Core.Repository.Abstractions;

namespace Inoxie.Tools.ApiServices.Services;

internal class DefaultWriteAuthorizationService<TEntity> : IWriteAuthorizationService<TEntity>
    where TEntity : IDataEntity
{
    public Task<bool> AuthorizeAsync(TEntity dto) => Task.FromResult(true);

    public Task<bool> AuthorizeDeleteAsync(Guid id) => Task.FromResult(true);

}
