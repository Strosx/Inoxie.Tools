using Inoxie.Tools.Core.Repository.Abstractions;
using System.Linq.Expressions;

namespace Inoxie.Tools.ApiServices.Abstractions.Interfaces;

public interface IReadAuthorizationService<TEntity, TId> 
    where TEntity: IDataEntity<TId>
{
    Expression<Func<TEntity, bool>> Get();
}
