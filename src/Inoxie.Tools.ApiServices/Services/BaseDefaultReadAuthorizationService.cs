using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using System.Linq.Expressions;
using Inoxie.Tools.Core.Repository.Abstractions;

namespace Inoxie.Tools.ApiServices.Services;

internal class BaseDefaultReadAuthorizationService<TEntity, TId> : IBaseReadAuthorizationService<TEntity, TId>
    where TEntity : IBaseDataEntity<TId>
{
    public Expression<Func<TEntity, bool>> Get() => x => true;
}