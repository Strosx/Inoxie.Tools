using Inoxie.Tools.ApiServices.GuidId.Abstractions;
using Inoxie.Tools.ApiServices.Services;
using Inoxie.Tools.Core.Repository.GuidId.Abstractions;

namespace Inoxie.Tools.ApiServices.GuidId.Services;

internal class DefaultReadAuthorizationService<TEntity> : BaseDefaultReadAuthorizationService<TEntity, Guid>, IReadAuthorizationService<TEntity>
    where TEntity : IDataEntity
{
}