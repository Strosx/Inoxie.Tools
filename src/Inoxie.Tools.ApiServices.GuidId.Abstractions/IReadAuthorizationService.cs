using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.Core.Repository.GuidId.Abstractions;

namespace Inoxie.Tools.ApiServices.GuidId.Abstractions;

public interface IReadAuthorizationService<TEntity> : IBaseReadAuthorizationService<TEntity, Guid>
    where TEntity : IDataEntity
{
}