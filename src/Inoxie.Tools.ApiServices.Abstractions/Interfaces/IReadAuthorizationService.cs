using Inoxie.Tools.Core.Repository.Abstractions;
using System.Linq.Expressions;

namespace Inoxie.Tools.ApiServices.Abstractions.Interfaces;

public interface IReadAuthorizationService<TEntity> 
    where TEntity: IDataEntity
{
    Expression<Func<TEntity, bool>> Get();
}
