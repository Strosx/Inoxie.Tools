using Inoxie.Tools.Example.Api.Services.PdfTemplating.Models;
using Inoxie.Tools.PdfTemplating.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inoxie.Tools.Example.Api.Controllers.Templates;

[Route("api/templates")]
public class TemplatesReadController : ControllerBase
{
    private readonly IPdfGenerator<ExamplePdfTemplateModel> pdfGenerator;

    public TemplatesReadController(IPdfGenerator<ExamplePdfTemplateModel> pdfGenerator)
    {
        this.pdfGenerator = pdfGenerator;
    }

    [HttpGet]
    public async Task<IActionResult> DownloadTemplate()
    {
        return File(await pdfGenerator.GenerateAsync(new ExamplePdfTemplateModel()
        {
            Test = "ahahahaha"
        }), "application/pdf", "template.pdf");
    }
}
