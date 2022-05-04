using AutoMapper;
using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.Core.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Inoxie.Tools.ApiServices.Services;

public class BaseReadService<TEntity, TOutDto, TId> : IBaseReadService<TOutDto, TId>
    where TEntity : IBaseDataEntity<TId>
{
    private readonly IMapper mapper;
    private readonly IBaseReadAuthorizationService<TEntity, TId> readAuthorizationService;
    private readonly IBaseReadRepository<TEntity, TId> readRepository;
    private readonly IReadServicePostProcessor<TOutDto> readServicePostProcessor;

    public BaseReadService(
        IBaseReadRepository<TEntity, TId> readRepository,
        IMapper mapper,
        IBaseReadAuthorizationService<TEntity, TId> readAuthorizationService,
        IReadServicePostProcessor<TOutDto> readServicePostProcessor)
    {
        this.readRepository = readRepository;
        this.mapper = mapper;
        this.readAuthorizationService = readAuthorizationService;
        this.readServicePostProcessor = readServicePostProcessor;
    }

    public virtual async Task<List<TOutDto>> GetAllAsync()
    {
        var query = readRepository.AsQueryable().Where(readAuthorizationService.Get());
        var materializedResults = await mapper.ProjectTo<TOutDto>(query).ToListAsync();
        return await readServicePostProcessor.ProcessCollectionAsync(materializedResults);
    }

    public virtual async Task<TOutDto> GetAsync(TId id)
    {
        var query = readRepository.AsQueryable().Where(readAuthorizationService.Get()).Where(x => Equals(x.Id, id));
        var mapped = await mapper.ProjectTo<TOutDto>(query).FirstAsync();

        if (mapped != null)
        {
            return await readServicePostProcessor.ProcessAsync(mapped);
        }

        var entity = await readRepository
            .AsQueryable()
            .FirstOrDefaultAsync(f => Equals(f.Id, id));

        if (entity != null) throw new Exception("Forbidden");

        throw new Exception("NotFound");
    }
}