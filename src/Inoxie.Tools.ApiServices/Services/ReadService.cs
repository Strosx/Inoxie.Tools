using AutoMapper;
using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.Core.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Inoxie.Tools.ApiServices.Services;

public class ReadService<TEntity, TOutDto> : IReadService<TOutDto>
    where TEntity : IDataEntity
{
    private readonly IReadRepository<TEntity> readRepository;
    private readonly IMapper mapper;
    private readonly IReadAuthorizationService<TEntity> readAuthorizationService;
    private readonly IReadServicePostProcessor<TOutDto> readServicePostProcessor;

    public ReadService(
        IReadRepository<TEntity> readRepository,
        IMapper mapper,
        IReadAuthorizationService<TEntity> readAuthorizationService,
        IReadServicePostProcessor<TOutDto> readServicePostProcessor)
    {
        this.readRepository = readRepository;
        this.mapper = mapper;
        this.readAuthorizationService = readAuthorizationService;
        this.readServicePostProcessor = readServicePostProcessor;
    }

    public async Task<List<TOutDto>> GetAllAsync()
    {
        var query = readRepository.AsQueryable().Where(readAuthorizationService.Get());
        var materializedResults = await mapper.ProjectTo<TOutDto>(query).ToListAsync();
        return await readServicePostProcessor.ProcessCollectionAsync(materializedResults);
    }

    public async Task<TOutDto> GetAsync(Guid id)
    {
        var query = readRepository.AsQueryable().Where(readAuthorizationService.Get()).Where(x => x.Id == id);
        var mapped = await mapper.ProjectTo<TOutDto>(query).FirstAsync();

        if (mapped != null)
        {
            return await readServicePostProcessor.ProcessAsync(mapped);
        }

        var entity = await readRepository
            .AsQueryable()
            .FirstOrDefaultAsync(f => f.Id == id);

        if (entity != null) throw new Exception("Forbidden");

        throw new Exception("NotFound");
    }
}
