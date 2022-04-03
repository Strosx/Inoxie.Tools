using AutoMapper;
using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.Core.Repository.Abstractions;
using Inoxie.Tools.DataProcessor.Abstractions.Interfaces;
using Inoxie.Tools.DataProcessor.Abstractions.Models;
using Microsoft.EntityFrameworkCore;

namespace Inoxie.Tools.ApiServices.Services;

public class FilteredReadService<TDb, TOutDto, TFilter> : ReadService<TDb, TOutDto>, IFilterReadService<TOutDto, TFilter>
    where TOutDto : class
    where TDb : class, IDataEntity
    where TFilter : BaseFilterModel

{
    private readonly IReadRepository<TDb> readRepository;
    private readonly IMapper mapper;
    private readonly IDataProcessor<TDb, TFilter> dataProcessor;
    private readonly IAuthorizationExpressionProvider<TDb> authorizationExpressionProvider;

    public FilteredReadService(
        IReadRepository<TDb> readRepository,
        IMapper mapper,
        IDataProcessor<TDb, TFilter> dataProcessor,
        IAuthorizationExpressionProvider<TDb> authorizationExpressionProvider)
        : base(readRepository, mapper, authorizationExpressionProvider)
    {
        this.readRepository = readRepository;
        this.mapper = mapper;
        this.dataProcessor = dataProcessor;
        this.authorizationExpressionProvider = authorizationExpressionProvider;
    }

    public async Task<PagedDataResponse<TOutDto>> FilterAsync(TFilter filter)
    {
        var query = readRepository.AsQueryable().Where(authorizationExpressionProvider.Get());

        var queryablePagedDataResponse = dataProcessor.ProcessQueryable(filter, query);
        var collection = await mapper.ProjectTo<TOutDto>(queryablePagedDataResponse.Collection).ToListAsync();

        return new PagedDataResponse<TOutDto>()
        {
            Collection = collection,
            Total = queryablePagedDataResponse.Total
        };
    }

    public Task<TOutDto> GetByFilterFirstAsync(TFilter filter)
    {
        var query = readRepository.AsQueryable().Where(authorizationExpressionProvider.Get());

        var queryablePagedDataResponse = dataProcessor.ProcessQueryable(filter, query);
        return mapper.ProjectTo<TOutDto>(queryablePagedDataResponse.Collection).FirstOrDefaultAsync();
    }
}
