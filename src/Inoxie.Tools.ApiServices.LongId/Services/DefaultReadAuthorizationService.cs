using Inoxie.Tools.ApiServices.LongId.Abstractions;
using Inoxie.Tools.ApiServices.Services;
using Inoxie.Tools.Core.Repository.LongId.Abstractions;

namespace Inoxie.Tools.ApiServices.LongId.Services;

internal class DefaultReadAuthorizationService<TEntity> : DefaultReadAuthorizationService<TEntity, long>, IReadAuthorizationService<TEntity>
    where TEntity : IDataEntity
{}