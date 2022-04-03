using Inoxie.Tools.Core.Repository.Abstractions;
using System.Linq.Expressions;

namespace Inoxie.Tools.ApiServices.Abstractions.Interfaces;

public interface IAuthorizationExpressionProvider<TEntity> 
    where TEntity: IDataEntity
{
    Expression<Func<TEntity, bool>> Get();
}
