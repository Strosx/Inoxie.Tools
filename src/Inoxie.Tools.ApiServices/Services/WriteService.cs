using AutoMapper;
using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.ApiServices.Utilities;
using Inoxie.Tools.Core.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Inoxie.Tools.ApiServices.Services;

public class WriteService<TDb, TInDto, TId> : IWriteService<TInDto, TId>
    where TDb : IDataEntity<TId>
{
    private readonly IMapper mapper;
    private readonly IReadRepository<TDb, TId> readRepository;
    private readonly IWriteAuthorizationService<TInDto, TId> writeAuthorizationService;
    private readonly IWriteRepository<TDb, TId> writeRepository;

    public WriteService(
        IWriteRepository<TDb, TId> writeRepository,
        IReadRepository<TDb, TId> readRepository,
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

        var mappedEntity = mapper.Map<TDb>(inDto);
        return await writeRepository.CreateAsync(mappedEntity);
    }

    public virtual async Task CreateManyAsync(List<TInDto> inDtos)
    {
        if (!await writeAuthorizationService.AuthorizeAsync(inDtos))
        {
            throw new Exception("Forbidden");
        }

        var mappedList = mapper.Map<List<TDb>>(inDtos);
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
        entity.MapPropertiesFrom<TDb, TInDto, TId>(inDto);

        await writeRepository.SaveChangesAsync();
    }
}