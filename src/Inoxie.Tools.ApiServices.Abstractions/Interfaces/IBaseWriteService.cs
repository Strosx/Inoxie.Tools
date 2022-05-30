namespace Inoxie.Tools.ApiServices.Abstractions.Interfaces;

public interface IBaseWriteService<TInDto, TId>
{
    Task<TId> CreateAsync(TInDto inDto);
    Task CreateManyAsync(List<TInDto> inDtos);
    Task DeleteAsync(TId id);
    Task UpdateAsync(TInDto inDto, TId id);
}