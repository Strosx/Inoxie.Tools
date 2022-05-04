using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.Core.Repository.LongId.Abstractions;

namespace Inoxie.Tools.ApiServices.LongId.Abstractions;

public interface IReadAuthorizationService<TEntity> : IReadAuthorizationService<TEntity, long>
    where TEntity : IDataEntity
{
}