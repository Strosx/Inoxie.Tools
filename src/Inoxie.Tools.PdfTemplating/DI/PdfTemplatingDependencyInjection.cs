using Inoxie.Tools.PdfTemplating.Implementations;
using Inoxie.Tools.PdfTemplating.Interfaces;
using Inoxie.Tools.Storage.DI;
using Microsoft.Extensions.DependencyInjection;

namespace Inoxie.Tools.PdfTemplating.DI;

public static class PdfTemplatingDependencyInjection
{
    internal static void Configure(IServiceCollection services)
    {
        services.AddInoxieToolsStorage();

        services.AddScoped(typeof(IPdfGenerator<>), typeof(PdfGenerator<>));
    }

    public static void AddPdfTemplating(this IServiceCollection services)
    {
        Configure(services);
    }
}
