using AutoMapper;
using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.Core.Repository.Abstractions;
using Inoxie.Tools.DataProcessor.Abstractions.Interfaces;
using Inoxie.Tools.DataProcessor.Abstractions.Models;
using Microsoft.EntityFrameworkCore;

namespace Inoxie.Tools.ApiServices.Services;

public class BaseFilteredReadService<TEntity, TOutDto, TFilter, TId> : BaseReadService<TEntity, TOutDto, TId>, IBaseFilterReadService<TOutDto, TFilter, TId>
    where TOutDto : class
    where TEntity : class, IBaseDataEntity<TId>
    where TFilter : BaseFilterModel
{
    private readonly IDataProcessor<TEntity, TFilter> dataProcessor;
    private readonly IMapper mapper;
    private readonly IReadServicePostProcessor<TOutDto> postProcessor;
    private readonly IBaseReadAuthorizationService<TEntity, TId> readAuthorizationService;
    private readonly IBaseReadRepository<TEntity, TId> readRepository;

    public BaseFilteredReadService(
        IBaseReadRepository<TEntity, TId> readRepository,
        IMapper mapper,
        IDataProcessor<TEntity, TFilter> dataProcessor,
        IBaseReadAuthorizationService<TEntity, TId> readAuthorizationService,
        IReadServicePostProcessor<TOutDto> postProcessor)
        : base(readRepository, mapper, readAuthorizationService, postProcessor)
    {
        this.readRepository = readRepository;
        this.mapper = mapper;
        this.dataProcessor = dataProcessor;
        this.readAuthorizationService = readAuthorizationService;
        this.postProcessor = postProcessor;
    }

    public virtual async Task<TOutDto> GetByFilterFirstAsync(TFilter filter)
    {
        var query = readRepository.AsQueryable().Where(await readAuthorizationService.Get());

        var queryablePagedDataResponse = dataProcessor.ProcessQueryable(filter, query);
        var mapped = await mapper.ProjectTo<TOutDto>(queryablePagedDataResponse.Collection).FirstOrDefaultAsync();

        if (mapped == null) throw new Exception("NotFound");

        return await postProcessor.ProcessAsync(mapped);
    }

    public virtual async Task<PagedDataResponse<TOutDto>> FilterAsync(TFilter filter)
    {
        var query = readRepository.AsQueryable().Where(await readAuthorizationService.Get());

        var queryablePagedDataResponse = dataProcessor.ProcessQueryable(filter, query);
        var collection = await mapper.ProjectTo<TOutDto>(queryablePagedDataResponse.Collection).ToListAsync();

        return new PagedDataResponse<TOutDto>()
        {
            Collection = await postProcessor.ProcessCollectionAsync(collection),
            Total = queryablePagedDataResponse.Total
        };
    }
}