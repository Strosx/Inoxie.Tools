using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace Inoxie.Tools.PdfGeneratorClient.DI;

public static class PdfGeneratorClientDependencyInjection
{
    public static void AddInoxiePdfGeneratorClient(this IServiceCollection services)
    {
        services.AddScoped<IPdfGeneratorClient, PdfGeneratorClient>(s =>
        {
            var httpClientFactory = s.GetRequiredService<IHttpClientFactory>();

            return new PdfGeneratorClient("https://api-tools.inoxiesoft.com", httpClientFactory.CreateClient());
        });
    }
}
