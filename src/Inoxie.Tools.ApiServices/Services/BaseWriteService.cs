using AutoMapper;
using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.ApiServices.Utilities;
using Inoxie.Tools.Core.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Inoxie.Tools.ApiServices.Services;

public class BaseWriteService<TEntity, TInDto, TId> : IBaseWriteService<TInDto, TId>
    where TEntity : IBaseDataEntity<TId>
{
    private readonly IDbSaveChanges dbSaveChanges;
    private readonly IMapper mapper;
    private readonly IBaseReadRepository<TEntity, TId> readRepository;
    private readonly IBaseWriteAuthorizationService<TInDto, TId> writeAuthorizationService;
    private readonly IBaseWriteRepository<TEntity, TId> writeRepository;

    public BaseWriteService(
        IBaseWriteRepository<TEntity, TId> writeRepository,
        IBaseReadRepository<TEntity, TId> readRepository,
        IMapper mapper,
        IBaseWriteAuthorizationService<TInDto, TId> writeAuthorizationService,
        IDbSaveChanges dbSaveChanges)
    {
        this.writeRepository = writeRepository;
        this.readRepository = readRepository;
        this.mapper = mapper;
        this.writeAuthorizationService = writeAuthorizationService;
        this.dbSaveChanges = dbSaveChanges;
    }

    public virtual async Task<TId> CreateAsync(TInDto inDto)
    {
        if (!await writeAuthorizationService.AuthorizeAsync(inDto))
        {
            throw new Exception("Forbidden");
        }

        var mappedEntity = mapper.Map<TEntity>(inDto);
        return await writeRepository.CreateAsync(mappedEntity);
    }

    public virtual async Task CreateManyAsync(List<TInDto> inDtos)
    {
        if (!await writeAuthorizationService.AuthorizeAsync(inDtos))
        {
            throw new Exception("Forbidden");
        }

        var mappedList = mapper.Map<List<TEntity>>(inDtos);
        await writeRepository.CreateManyAsync(mappedList);
    }

    public virtual async Task DeleteAsync(TId id)
    {
        if (!await writeAuthorizationService.AuthorizeDeleteAsync(id))
        {
            throw new Exception("Forbidden");
        }

        await writeRepository.DeleteAsync(id);
    }

    public virtual async Task UpdateAsync(TInDto inDto, TId id)
    {
        if (!await writeAuthorizationService.AuthorizeAsync(inDto))
        {
            throw new Exception("Forbidden");
        }

        var entity = await readRepository.AsQueryable(true).FirstOrDefaultAsync(f => Equals(f.Id, id));
        entity.MapPropertiesFrom<TEntity, TInDto, TId>(inDto);

        await dbSaveChanges.SaveChangesAsync();
    }
}