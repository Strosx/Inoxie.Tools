namespace Inoxie.Tools.KeyWarehouse.Client.Models
{
    public class WarehouseOrderKeysOutDto
    {
        public string OrderId { get; set; }
        public List<WarehouseOrderKeyItemOutDto> Items { get; set; }
    }
}
