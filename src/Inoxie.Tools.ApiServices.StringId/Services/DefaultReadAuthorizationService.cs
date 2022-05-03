using Inoxie.Tools.ApiServices.Services;
using Inoxie.Tools.ApiServices.StringId.Abstractions;
using Inoxie.Tools.Core.Repository.StringId.Abstractions;

namespace Inoxie.Tools.ApiServices.StringId.Services;

internal class DefaultReadAuthorizationService<TEntity> : DefaultReadAuthorizationService<TEntity, string>, IReadAuthorizationService<TEntity>
    where TEntity : IDataEntity
{
}