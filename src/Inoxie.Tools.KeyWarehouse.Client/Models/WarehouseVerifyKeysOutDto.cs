namespace Inoxie.Tools.KeyWarehouse.Client.Models;

public class WarehouseVerifyKeysOutDto
{
    public List<WarehouseVerifyKeyItemOutDto> Items { get; set; }

}

public class WarehouseVerifyKeyItemOutDto
{
    public string Message { get; set; }
    public string Key { get; set; }
    public bool IsUsed { get; set; }
}

