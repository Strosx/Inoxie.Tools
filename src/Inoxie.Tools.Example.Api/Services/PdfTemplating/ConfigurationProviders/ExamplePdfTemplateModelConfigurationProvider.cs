using Inoxie.Tools.Example.Api.Services.PdfTemplating.Models;
using Inoxie.Tools.PdfTemplating.Interfaces;

namespace Inoxie.Tools.Example.Api.Services.PdfTemplating.ConfigurationProviders;

public class ExamplePdfTemplateModelConfigurationProvider : IPdfTemplateConfigurationProvider<ExamplePdfTemplateModel>
{
    public string TemplateUri => "https://softflixprodstorage.blob.core.windows.net/pdftemplates/LicenseCertificateDE.html";
}
