using Inoxie.Tools.KeyWarehouse.Client.DI;
using Inoxie.Tools.KeyWarehouse.Client.Interfaces;
using Inoxie.Tools.KeyWarehouse.Client.Models;
using Inoxie.Tools.KeyWarehouse.Client.Utilities;
using System.Net.Http.Json;

namespace Inoxie.Tools.KeyWarehouse.Client.Implementations
{
    internal class WarehouseKeysReadClient : IWarehouseKeysReadClient
    {
        private readonly HttpClient httpClient;

        public WarehouseKeysReadClient(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient(KeyWarehouseClientDependencyInjection.KeyWarehouseHttpClientName);
        }


        public async Task<int> GetAvailability(WarehouseGetKeysAvailabilityInDto warehouseGetKeysAvailabilityInDto)
        {
            var response = await httpClient.PostAsJsonAsync(Routing.GetAvailability, warehouseGetKeysAvailabilityInDto);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task<Dictionary<Guid, int>> GetMultipleAvailability(List<WarehouseGetKeysAvailabilityInDto> warehouseGetKeysAvailabilityInDtos)
        {
            var response = await httpClient.PostAsJsonAsync(Routing.GetMultipleAvailability, warehouseGetKeysAvailabilityInDtos);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Dictionary<Guid, int>>();
        }

        public async Task<WarehouseOrderKeysOutDto> Order(WarehouseOrderKeysInDto warehouseOrderKeysInDto)
        {
            var response = await httpClient.PostAsJsonAsync(Routing.Order, warehouseOrderKeysInDto);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<WarehouseOrderKeysOutDto>();
        }
    }
}
