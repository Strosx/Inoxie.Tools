namespace Inoxie.Tools.KeyWarehouse.Client.Models;

public class WarehouseOrderKeysInDto
{
    public string OrderId { get; set; }
    public List<WarehouseOrderKeyItemInDto> Items { get; set; }
}
