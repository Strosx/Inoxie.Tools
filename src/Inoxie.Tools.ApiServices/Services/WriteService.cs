using AutoMapper;
using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.ApiServices.Utilities;
using Inoxie.Tools.Core.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Inoxie.Tools.ApiServices.Services;

public class WriteService<TDb, TInDto> : IWriteService<TInDto>
    where TDb : IDataEntity
{
    private readonly IWriteRepository<TDb> writeRepository;
    private readonly IReadRepository<TDb> readRepository;
    private readonly IMapper mapper;
    private readonly IWriteAuthorizationService<TInDto> writeAuthorizationService;

    public WriteService(
        IWriteRepository<TDb> writeRepository,
        IReadRepository<TDb> readRepository,
        IMapper mapper,
        IWriteAuthorizationService<TInDto> writeAuthorizationService)
    {
        this.writeRepository = writeRepository;
        this.readRepository = readRepository;
        this.mapper = mapper;
        this.writeAuthorizationService = writeAuthorizationService;
    }

    public virtual async Task<Guid> CreateAsync(TInDto inDto)
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

    public virtual async Task DeleteAsync(Guid id)
    {
        if (!await writeAuthorizationService.AuthorizeDeleteAsync(id))
        {
            throw new Exception("Forbidden");
        }

        await writeRepository.DeleteAsync(id);
    }

    public virtual async Task UpdateAsync(TInDto inDto, Guid id)
    {
        if (!await writeAuthorizationService.AuthorizeAsync(inDto))
        {
            throw new Exception("Forbidden");
        }

        var entity = await readRepository.AsQueryable(true).FirstOrDefaultAsync(f => f.Id == id);
        entity.MapPropertiesFrom(inDto);

        await writeRepository.SaveChangesAsync();
    }
}
