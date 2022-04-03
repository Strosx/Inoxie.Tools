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
    private readonly IAuthorizationExpressionProvider<TEntity> authorizationExpressionProvider;

    public ReadService(
        IReadRepository<TEntity> readRepository,
        IMapper mapper,
        IAuthorizationExpressionProvider<TEntity> authorizationExpressionProvider)
    {
        this.readRepository = readRepository;
        this.mapper = mapper;
        this.authorizationExpressionProvider = authorizationExpressionProvider;
    }

    public Task<List<TOutDto>> GetAllAsync()
    {
        var query = readRepository.AsQueryable().Where(authorizationExpressionProvider.Get());
        return mapper.ProjectTo<TOutDto>(query).ToListAsync();
    }

    public Task<TOutDto> GetAsync(Guid id)
    {
        var query = readRepository.AsQueryable().Where(authorizationExpressionProvider.Get()).Where(x => x.Id == id);
        return mapper.ProjectTo<TOutDto>(query).FirstAsync();
    }
}
