using Inoxie.Tools.Core.Repository.Abstractions;
using System.Linq.Expressions;

namespace Inoxie.Tools.ApiServices.Abstractions.Interfaces;

public interface IBaseReadAuthorizationService<TEntity, TId>
    where TEntity : IBaseDataEntity<TId>
{
    Expression<Func<TEntity, bool>> Get();
}