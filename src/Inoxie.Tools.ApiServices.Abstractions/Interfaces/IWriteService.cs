namespace Inoxie.Tools.ApiServices.Abstractions.Interfaces;

public interface IWriteService<TInDto>
{
    Task<Guid> CreateAsync(TInDto inDto);
    Task CreateManyAsync(List<TInDto> inDtos);
    Task DeleteAsync(Guid id);
    Task UpdateAsync(TInDto inDto, Guid id);    
}
