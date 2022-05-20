using Inoxie.Tools.Storage.Implementations;
using Inoxie.Tools.Storage.Implementations.Internal;
using Inoxie.Tools.Storage.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Inoxie.Tools.Storage.DI;
public static class InoxieToolsStorageDependencyInjection
{
    internal static void Configure(IServiceCollection services)
    {
        services.AddScoped<InoxieBlobClient>();
        services.AddScoped<IBlobStorageClient, BlobStorageClient>();
    }

    public static void AddInoxieToolsStorage(this IServiceCollection services)
    {
        Configure(services);
    }
}
