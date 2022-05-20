using HandlebarsDotNet;
using Inoxie.Tools.PdfTemplating.Interfaces;
using Inoxie.Tools.PdfTemplating.Models;
using Inoxie.Tools.Storage.Interfaces;
using System.IO;
using System.Threading.Tasks;
using SelectPdf;

namespace Inoxie.Tools.PdfTemplating.Implementations;

internal class PdfGenerator<TTemplateModel> : IPdfGenerator<TTemplateModel>
    where TTemplateModel : BaseTemplateModel
{
    private readonly IPdfTemplateConfigurationProvider<TTemplateModel> configurationProvider;
    private readonly IBlobStorageClient blobStorageClient;

    public PdfGenerator(
        IPdfTemplateConfigurationProvider<TTemplateModel> configurationProvider,
        IBlobStorageClient blobStorageClient)
    {
        this.configurationProvider = configurationProvider;
        this.blobStorageClient = blobStorageClient;
    }


    public async Task<Stream> GenerateAsync(TTemplateModel model)
    {
        var templateStream = await blobStorageClient.DownloadAsync(configurationProvider.TemplateUri);

        templateStream.Position = 0;
        templateStream.Seek(0, SeekOrigin.Begin);

        var streamReader = new StreamReader(templateStream);
        var test = templateStream.Length;
        var htmlTemplateString = await streamReader.ReadToEndAsync();

        var template = Handlebars.Compile(htmlTemplateString);

        var parsedHtmlResult = template(model);

        var converter = new HtmlToPdf();
        var doc = converter.ConvertHtmlString(parsedHtmlResult);

        var stream = new MemoryStream();
        doc.Save(stream);

        stream.Position = 0;
        stream.Seek(0, SeekOrigin.Begin);

        return stream;
    }
}
