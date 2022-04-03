namespace Inoxie.Tools.ApiServices.Abstractions.Interfaces;

public interface IReadService<TOutDto>
{
    Task<List<TOutDto>> GetAllAsync();
    Task<TOutDto> GetAsync(Guid id);
}
