namespace Inoxie.Tools.ApiServices.Abstractions.Interfaces;

public interface IBaseReadService<TOutDto, in TId>
{
    Task<List<TOutDto>> GetAllAsync();
    Task<TOutDto> GetAsync(TId id);
}
