namespace Inoxie.Tools.KeyWarehouse.Client.Models
{
    public class WarehouseGetKeysAvailabilityInDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public WarehouseKeyQuality MinQuality { get; set; }
        public WarehouseKeyQuality MaxQuality { get; set; }
    }
}
