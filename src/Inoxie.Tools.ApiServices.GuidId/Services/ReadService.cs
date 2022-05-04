using AutoMapper;
using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.ApiServices.GuidId.Abstractions;
using Inoxie.Tools.ApiServices.Services;
using Inoxie.Tools.Core.Repository.GuidId.Abstractions;

namespace Inoxie.Tools.ApiServices.GuidId.Services;

public class ReadService<TEntity, TOutDto> : BaseReadService<TEntity, TOutDto, Guid>, IReadService<TOutDto>
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