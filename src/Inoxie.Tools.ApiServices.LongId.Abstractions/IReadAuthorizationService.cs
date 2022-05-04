using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.Core.Repository.LongId.Abstractions;

namespace Inoxie.Tools.ApiServices.LongId.Abstractions;

public interface IReadAuthorizationService<TEntity> : IBaseReadAuthorizationService<TEntity, long>
    where TEntity : IDataEntity
{
}