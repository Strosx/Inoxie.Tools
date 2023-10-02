using Inoxie.Tools.Storage.Implementations;
using Inoxie.Tools.Storage.Implementations.Internal;
using Inoxie.Tools.Storage.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Inoxie.Tools.Storage.DI;

/// <summary>
/// Extension methods for service collection to register storage services.
/// </summary>
public static class InoxieToolsStorageDependencyInjection
{
    /// <summary>
    /// Configures services for blob storage operations.
    /// </summary>
    internal static void Configure(IServiceCollection services)
    {
        services.AddScoped<InoxieBlobClient>();
        services.AddScoped<IBlobStorageClient, BlobStorageClient>();
    }

    /// <summary>
    /// Registers blob storage services in the provided services collection.
    /// </summary>
    public static void AddInoxieToolsStorage(this IServiceCollection services)
    {
        Configure(services);
    }
}
