using Inoxie.Tools.KeyWarehouse.Client.Models;

namespace Inoxie.Tools.KeyWarehouse.Client.Interfaces
{
    public interface IWarehouseKeysWriteClient
    {
        Task Create(WarehouseCreateKeyInDto warehouseCreateKeyInDto);
        Task CreateMany(List<WarehouseCreateKeyInDto> warehouseCreateKeysInDto);
        Task Return(WarehouseReturnKeysInDto warehouseReturnKeysInDto);
    }
}
