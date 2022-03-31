using Inoxie.Tools.KeyWarehouse.Client.DI;
using Inoxie.Tools.KeyWarehouse.Client.Interfaces;
using Inoxie.Tools.KeyWarehouse.Client.Models;
using Inoxie.Tools.KeyWarehouse.Client.Utilities;
using System.Net.Http.Json;

namespace Inoxie.Tools.KeyWarehouse.Client.Implementations
{
    internal class WarehouseProductsWriteClient : IWarehouseProductsWriteClient
    {
        private readonly HttpClient httpClient;

        public WarehouseProductsWriteClient(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient(KeyWarehouseClientDependencyInjection.KeyWarehouseHttpClientName);
        }

        public async Task<Guid> CreateAsync(WarehouseProductInDto warehouseProductInDto)
        {
            var response = await httpClient.PostAsJsonAsync(Routing.CreateProduct, warehouseProductInDto);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Guid>();
        }
    }
}
