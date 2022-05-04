using AutoMapper;
using Inoxie.Tools.ApiServices.Services;
using Inoxie.Tools.ApiServices.StringId.Abstractions;
using Inoxie.Tools.Core.Repository.StringId.Abstractions;

namespace Inoxie.Tools.ApiServices.StringId.Services;

public class WriteService<TEntity, TInDto> : BaseWriteService<TEntity, TInDto, string>, IWriteService<TInDto>
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