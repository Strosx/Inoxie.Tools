using Inoxie.Tools.KeyWarehouse.Client.Models;

namespace Inoxie.Tools.KeyWarehouse.Client.Interfaces
{
    public interface IWarehouseKeysWriteClient
    {
        Task Create(WarehouseCreateKeyInDto warehouseCreateKeyInDto, HttpClient authorizedHttp = null);
        Task CreateMany(List<WarehouseCreateKeyInDto> warehouseCreateKeysInDto, HttpClient authorizedHttp = null);
        Task Return(WarehouseReturnKeysInDto warehouseReturnKeysInDto);
    }
}
