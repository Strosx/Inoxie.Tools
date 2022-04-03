using Inoxie.Tools.KeyWarehouse.Client.Models;

namespace Inoxie.Tools.KeyWarehouse.Client.Interfaces;

public interface IWarehouseKeysReadClient
{
    Task<WarehouseOrderKeysOutDto> Order(WarehouseOrderKeysInDto warehouseOrderKeysInDto);
    Task<int> GetAvailability(WarehouseGetKeysAvailabilityInDto warehouseGetKeysAvailabilityInDto);
    Task<Dictionary<Guid, int>> GetMultipleAvailability(List<WarehouseGetKeysAvailabilityInDto> warehouseGetKeysAvailabilityInDtos);
    Task<WarehouseVerifyKeysOutDto> VerifyKeys(WarehouseVerifyKeysInDto warehouseVerifyKeysInDto);
}
