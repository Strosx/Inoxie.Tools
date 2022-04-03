namespace Inoxie.Tools.KeyWarehouse.Client.Models;

public class WarehouseCreateKeyInDto
{
    public WarehouseCreateKeyInDto(string value, WarehouseKeyQuality quality, WarehouseKeyStatus status, WarehouseKeyType type, Guid productId)
    {
        Value = value;
        Quality = quality;
        Status = status;
        Type = type;
        ProductId = productId;
    }

    public string Value { get; set; }
    public WarehouseKeyQuality Quality { get; set; }
    public WarehouseKeyStatus Status { get; set; }
    public WarehouseKeyType Type { get; set; }

    public Guid ProductId { get; set; }
}
