namespace Inoxie.Tools.KeyWarehouse.Client.Models
{
    public class WarehouseVerifyKeysInDto
    {
        public List<WarehouseVerifyKeyItemInDto> Items { get; set; }
    }

    public class WarehouseVerifyKeyItemInDto
    {
        public string Key { get; set; }
    }

}
