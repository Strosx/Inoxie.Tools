namespace Inoxie.Tools.KeyWarehouse.Client.Configuration
{
    public class WarehouseClientConfiguration
    {
        public const string Key = "WarehouseConfiguration";

        public string Username { get; set; }
        public string Password { get; set; }
        public string BaseAddress { get; set; }
    }
}
