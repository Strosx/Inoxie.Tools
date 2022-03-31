using Inoxie.Tools.KeyWarehouse.Client.Models;

namespace Inoxie.Tools.KeyWarehouse.Client.Interfaces
{
    public interface IWarehouseProductsWriteClient
    {
        Task<Guid> CreateAsync(WarehouseProductInDto warehouseProductInDto);
    }
}
