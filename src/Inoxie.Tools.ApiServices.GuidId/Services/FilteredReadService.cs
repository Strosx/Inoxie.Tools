﻿using AutoMapper;
using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.ApiServices.GuidId.Abstractions;
using Inoxie.Tools.ApiServices.Services;
using Inoxie.Tools.Core.Repository.GuidId.Abstractions;
using Inoxie.Tools.DataProcessor.Abstractions.Interfaces;
using Inoxie.Tools.DataProcessor.Abstractions.Models;

namespace Inoxie.Tools.ApiServices.GuidId.Services;

public class FilteredReadService<TEntity, TOutDto, TFilter> : FilteredReadService<TEntity, TOutDto, TFilter, Guid>, IFilterReadService<TOutDto, TFilter>
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