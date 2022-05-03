using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.Core.Repository.StringId.Abstractions;

namespace Inoxie.Tools.ApiServices.StringId.Abstractions;

public interface IReadAuthorizationService<TEntity> : IReadAuthorizationService<TEntity, string>
    where TEntity : IDataEntity
{
}