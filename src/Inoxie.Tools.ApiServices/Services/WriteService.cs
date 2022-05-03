using AutoMapper;
using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.ApiServices.Utilities;
using Inoxie.Tools.Core.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Inoxie.Tools.ApiServices.Services;

public class WriteService<TEntity, TInDto, TId> : IWriteService<TInDto, TId>
    where TEntity : IDataEntity<TId>
{
    private readonly IMapper mapper;
    private readonly IReadRepository<TEntity, TId> readRepository;
    private readonly IWriteAuthorizationService<TInDto, TId> writeAuthorizationService;
    private readonly IWriteRepository<TEntity, TId> writeRepository;

    public WriteService(
        IWriteRepository<TEntity, TId> writeRepository,
        IReadRepository<TEntity, TId> readRepository,
        IMapper mapper,
        IWriteAuthorizationService<TInDto, TId> writeAuthorizationService)
    {
        this.writeRepository = writeRepository;
        this.readRepository = readRepository;
        this.mapper = mapper;
        this.writeAuthorizationService = writeAuthorizationService;
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

        await writeRepository.SaveChangesAsync();
    }
}