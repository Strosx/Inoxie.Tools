using HandlebarsDotNet;
using Inoxie.Tools.PdfTemplating.Interfaces;
using Inoxie.Tools.PdfTemplating.Models;
using Inoxie.Tools.Storage.Interfaces;
using System.IO;
using System.Threading.Tasks;
using SelectPdf;
using System.Net.Http;
using System;
using System.Collections.Generic;

namespace Inoxie.Tools.PdfTemplating.Implementations;

internal class PdfGenerator<TTemplateModel> : IPdfGenerator<TTemplateModel>
    where TTemplateModel : BaseTemplateModel
{
    private readonly HttpClient httpClient;

    public PdfGenerator(
        HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }


    public async Task<Stream> GenerateAsync(TTemplateModel model)
    {
        var templateStream = await httpClient.GetStreamAsync("http://127.0.0.1:5500/src/templates/keycher/ag-invoice/AgInvoice.html");

        //templateStream.Position = 0;
        //templateStream.Seek(0, SeekOrigin.Begin);

        var streamReader = new StreamReader(templateStream);
        var htmlTemplateString = await streamReader.ReadToEndAsync();

        var template = Handlebars.Compile(htmlTemplateString);

        var parsedHtmlResult = template(new
        {
            Name = "QDS SOLUTIONS FZCO",
            Address = "101 Building A2 DSO IFZA",
            ZipCode = "342001",
            City = "Dubai",
            Country = "United Arab Emirates",
            CompanyId = "DSO-FZCO-5601",
            Date = DateTime.UtcNow.ToString("yyyy:MM:dd HH:mm:ss"),
            InvoiceNumber = 2022060100001,
            OrderedProducts = new List<object>()
            {
                new
                {
                    Index = "1.",
                    ProductId = "100012",
                    ProductName = "Horizon Zero Dawn",
                    Quantity = 1,
                    UnitPrice= "19.99",
                    TotalGross = "19.99"
                },
                new
                {
                    Index = "2.",
                    ProductId = "100011",
                    ProductName = "God of War",
                    Quantity = 1,
                    UnitPrice= "49.99",
                    TotalGross = "49.99"
                },
                new
                {
                    Index = "3.",
                    ProductId = "100015",
                    ProductName = "Dying Light: Platinum Edition",
                    Quantity = 1,
                    UnitPrice= "49.99",
                    TotalGross = "49.99"
                },
                new
                {
                    Index = "4.",
                    ProductId = "100010",
                    ProductName = "Potion Permit",
                    Quantity = 10,
                    UnitPrice= "9.99",
                    TotalGross = "99.99"
                },
            },
            TotalGross = "649.99"
        });

        var converter = new HtmlToPdf();
        converter.Options.PdfPageSize = PdfPageSize.A4;
        converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
        converter.Options.MarginTop = 5;
        converter.Options.DisplayHeader = true;
        converter.Options.DisplayFooter = true;
        converter.Header.Height = 90;
        converter.Footer.Height = 70;

        converter.Options.EmbedFonts = true;

        var headerHtml = new PdfHtmlSection("https://softflixprodstorage.blob.core.windows.net/media/keycher/agheader.png");
        var footerHtml = new PdfHtmlSection("https://softflixprodstorage.blob.core.windows.net/media/keycher/agfooter.png");

        converter.Header.Add(headerHtml);
        converter.Footer.Add(footerHtml);

        var doc = converter.ConvertHtmlString(parsedHtmlResult);

        var stream = new MemoryStream();
        doc.Save(stream);

        stream.Position = 0;
        stream.Seek(0, SeekOrigin.Begin);

        return stream;
    }
}
