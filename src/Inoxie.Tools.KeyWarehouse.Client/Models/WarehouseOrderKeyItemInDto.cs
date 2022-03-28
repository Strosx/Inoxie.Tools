namespace Inoxie.Tools.KeyWarehouse.Client.Models
{
    public class WarehouseOrderKeyItemInDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public WarehouseKeyQuality MinQuality { get; set; }
        public WarehouseKeyQuality MaxQuality { get; set; }
        public WarehouseKeyType KeyType { get; set; }
    }
}
