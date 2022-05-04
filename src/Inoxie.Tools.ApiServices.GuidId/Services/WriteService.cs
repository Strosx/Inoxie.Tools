using AutoMapper;
using Inoxie.Tools.ApiServices.GuidId.Abstractions;
using Inoxie.Tools.ApiServices.Services;
using Inoxie.Tools.Core.Repository.GuidId.Abstractions;

namespace Inoxie.Tools.ApiServices.GuidId.Services;

public class WriteService<TEntity, TInDto> : WriteService<TEntity, TInDto, Guid>, IWriteService<TInDto>
    where TEntity : IDataEntity
{
    public WriteService(
        IWriteRepository<TEntity> writeRepository,
        IReadRepository<TEntity> readRepository,
        IMapper mapper,
        IWriteAuthorizationService<TInDto> writeAuthorizationService)
        : base(writeRepository, readRepository, mapper, writeAuthorizationService)
    {
    }
}