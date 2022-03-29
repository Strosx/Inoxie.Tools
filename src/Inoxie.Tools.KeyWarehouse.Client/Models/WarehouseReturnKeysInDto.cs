namespace Inoxie.Tools.KeyWarehouse.Client.Models
{
    public class WarehouseReturnKeysInDto
    {
        public List<WarehouseReturnKeysItemInDto> Items { get; set; }
    }

    public class WarehouseReturnKeysItemInDto
    {
        public string Key { get; set; }
    }
}
