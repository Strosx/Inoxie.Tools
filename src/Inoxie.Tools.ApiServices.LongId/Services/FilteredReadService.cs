using AutoMapper;
using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.ApiServices.LongId.Abstractions;
using Inoxie.Tools.ApiServices.Services;
using Inoxie.Tools.Core.Repository.LongId.Abstractions;
using Inoxie.Tools.DataProcessor.Abstractions.Interfaces;
using Inoxie.Tools.DataProcessor.Abstractions.Models;

namespace Inoxie.Tools.ApiServices.LongId.Services;

public class FilteredReadService<TEntity, TOutDto, TFilter> : BaseFilteredReadService<TEntity, TOutDto, TFilter, long>, IFilterReadService<TOutDto, TFilter>
    where TOutDto : class
    where TEntity : class, IDataEntity
    where TFilter : BaseFilterModel
{
    public FilteredReadService(
        IReadRepository<TEntity> readRepository,
        IMapper mapper,
        IDataProcessor<TEntity, TFilter> dataProcessor,
        IReadAuthorizationService<TEntity> readAuthorizationService,
        IReadServicePostProcessor<TOutDto> postProcessor)
        : base(readRepository, mapper, dataProcessor, readAuthorizationService, postProcessor)
    {
    }
}