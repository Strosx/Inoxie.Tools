using AutoMapper;
using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.ApiServices.LongId.Abstractions;
using Inoxie.Tools.ApiServices.Services;
using Inoxie.Tools.Core.Repository.LongId.Abstractions;

namespace Inoxie.Tools.ApiServices.LongId.Services;

public class ReadService<TEntity, TOutDto> : ReadService<TEntity, TOutDto, long>, IReadService<TOutDto>
    where TEntity : IDataEntity
{
    public ReadService(
        IReadRepository<TEntity> readRepository,
        IMapper mapper,
        IReadAuthorizationService<TEntity> readAuthorizationService,
        IReadServicePostProcessor<TOutDto> readServicePostProcessor)
        : base(readRepository, mapper, readAuthorizationService, readServicePostProcessor)
    {
    }
}