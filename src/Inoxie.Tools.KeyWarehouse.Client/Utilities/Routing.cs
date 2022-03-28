﻿namespace Inoxie.Tools.KeyWarehouse.Client.Utilities
{
    internal class Routing
    {
        //read
        public const string Order = "/api/keys/order";
        public const string GetAvailability = "/api/keys/availability";
        public const string GetMultipleAvailability = "/api/keys/availability-multiple";

        //write
        public const string Create = "/api/keys/create";
        public const string CreateMany = "/api/keys/create-many";
    }
}