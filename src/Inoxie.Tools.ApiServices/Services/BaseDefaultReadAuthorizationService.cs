using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using System.Linq.Expressions;
using Inoxie.Tools.Core.Repository.Abstractions;

namespace Inoxie.Tools.ApiServices.Services;

internal class BaseDefaultReadAuthorizationService<TEntity, TId> : IBaseReadAuthorizationService<TEntity, TId>
    where TEntity : IBaseDataEntity<TId>
{
    public Task<Expression<Func<TEntity, bool>>> Get() => Task.FromResult<Expression<Func<TEntity, bool>>>(x => true);
}