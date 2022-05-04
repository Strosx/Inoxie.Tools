using AutoMapper;
using Inoxie.Tools.ApiServices.LongId.Abstractions;
using Inoxie.Tools.ApiServices.Services;
using Inoxie.Tools.Core.Repository.LongId.Abstractions;

namespace Inoxie.Tools.ApiServices.LongId.Services;

public class WriteService<TEntity, TInDto> : BaseWriteService<TEntity, TInDto, long>, IWriteService<TInDto>
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