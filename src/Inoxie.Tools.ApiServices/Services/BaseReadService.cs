using AutoMapper;
using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.Core.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Inoxie.Tools.ApiServices.Services;

/// <summary>
/// Provides basic implementation for reading operations on entities of type <typeparamref name="TEntity"/>.
/// </summary>
/// <remarks>
/// This service handles authorization, mapping, and post-processing of data entities. It primarily uses <see cref="IBaseReadRepository{TEntity, TId}"/>, <see cref="IMapper"/>, <see cref="IBaseReadAuthorizationService{TEntity, TId}"/>, and <see cref="IReadServicePostProcessor{TOutDto}"/>.
/// </remarks>
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
        var query = readRepository.AsQueryable().Where(await readAuthorizationService.Get());
        var materializedResults = await mapper.ProjectTo<TOutDto>(query).ToListAsync();
        return await readServicePostProcessor.ProcessCollectionAsync(materializedResults);
    }

    public virtual async Task<TOutDto> GetAsync(TId id)
    {
        var query = readRepository.AsQueryable().Where(await readAuthorizationService.Get()).Where(x => Equals(x.Id, id));
        var mapped = await mapper.ProjectTo<TOutDto>(query).FirstOrDefaultAsync();

        if (mapped != null)
        {
            return await readServicePostProcessor.ProcessAsync(mapped);
        }

        var entity = await readRepository
            .AsQueryable()
            .FirstOrDefaultAsync(f => Equals(f.Id, id));

        if (entity != null)
        {
            throw new UnauthorizedAccessException($"Access denied for the entity of type {typeof(TEntity).Name} with ID '{id}'.");
        }

        throw new KeyNotFoundException($"Entity of type {typeof(TEntity).Name} with ID '{id}' was not found.");
    }
}