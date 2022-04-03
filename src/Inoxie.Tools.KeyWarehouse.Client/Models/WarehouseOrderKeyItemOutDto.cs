namespace Inoxie.Tools.KeyWarehouse.Client.Models;

public class WarehouseOrderKeyItemOutDto
{
    public Guid ProductId { get; set; }
    public List<string> Keys { get; set; }
}
