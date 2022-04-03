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

    public WriteService(
        IWriteRepository<TDb> writeRepository,
        IReadRepository<TDb> readRepository,
        IMapper mapper)
    {
        this.writeRepository = writeRepository;
        this.readRepository = readRepository;
        this.mapper = mapper;
    }

    public Task<Guid> CreateAsync(TInDto inDto)
    {
        var mappedEntity = mapper.Map<TDb>(inDto);
        return writeRepository.CreateAsync(mappedEntity);
    }

    public Task CreateManyAsync(List<TInDto> inDtos)
    {
        var mappedList = mapper.Map<List<TDb>>(inDtos);
        return writeRepository.CreateManyAsync(mappedList);
    }

    public Task DeleteAsync(Guid id)
    {
        return writeRepository.DeleteAsync(id);
    }

    public async Task UpdateAsync(TInDto inDto, Guid id)
    {
        var entity = await readRepository.AsQueryable(true).FirstOrDefaultAsync(f => f.Id == id);
        entity.MapPropertiesFrom(inDto);

        await writeRepository.SaveChangesAsync();
    }
}
