using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.Core.Repository.Abstractions;
using System.Linq.Expressions;

namespace Inoxie.Tools.ApiServices.Services;

internal class DefaultAuthorizationExpressionProvider<TEntity> : IAuthorizationExpressionProvider<TEntity>
    where TEntity : IDataEntity
{
    public Expression<Func<TEntity, bool>> Get() => x => true;
}
