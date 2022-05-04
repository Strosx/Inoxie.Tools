using AutoMapper;
using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.ApiServices.Services;
using Inoxie.Tools.ApiServices.StringId.Abstractions;
using Inoxie.Tools.Core.Repository.StringId.Abstractions;

namespace Inoxie.Tools.ApiServices.StringId.Services;

public class ReadService<TEntity, TOutDto> : ReadService<TEntity, TOutDto, string>, IReadService<TOutDto>
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