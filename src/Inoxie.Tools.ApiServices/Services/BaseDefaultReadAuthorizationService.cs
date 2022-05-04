using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.Core.Repository.Abstractions;
using System.Linq.Expressions;

namespace Inoxie.Tools.ApiServices.Services;

internal class BaseDefaultReadAuthorizationService<TEntity, TId> : IBaseReadAuthorizationService<TEntity, TId>
    where TEntity : IBaseDataEntity<TId>
{
    public Expression<Func<TEntity, bool>> Get() => x => true;
}