using Inoxie.Tools.KeyWarehouse.Client.DI;
using Inoxie.Tools.KeyWarehouse.Client.Interfaces;
using Inoxie.Tools.KeyWarehouse.Client.Models;
using Inoxie.Tools.KeyWarehouse.Client.Utilities;
using System.Net.Http.Json;

namespace Inoxie.Tools.KeyWarehouse.Client.Implementations
{
    internal class WarehouseKeysWriteClient : IWarehouseKeysWriteClient
    {
        private readonly HttpClient httpClient;

        public WarehouseKeysWriteClient(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient(KeyWarehouseClientDependencyInjection.KeyWarehouseHttpClientName);
        }

        public async Task Create(WarehouseCreateKeyInDto warehouseCreateKeyInDto, HttpClient http = null)
        {
            var httpClientToUse = http ?? httpClient;
               
            var response = await httpClientToUse.PostAsJsonAsync(Routing.Create, warehouseCreateKeyInDto);
            response.EnsureSuccessStatusCode();
        }

        public async Task CreateMany(List<WarehouseCreateKeyInDto> warehouseCreateKeysInDto, HttpClient http = null)
        {
            var httpClientToUse = http ?? httpClient;

            var response = await httpClientToUse.PostAsJsonAsync(Routing.CreateMany, warehouseCreateKeysInDto);
            response.EnsureSuccessStatusCode();
        }

        public async Task Return(WarehouseReturnKeysInDto warehouseReturnKeysInDto)
        {
            var response = await httpClient.PostAsJsonAsync(Routing.Return, warehouseReturnKeysInDto);
            response.EnsureSuccessStatusCode();
        }
    }
}
