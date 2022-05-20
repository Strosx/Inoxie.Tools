using Inoxie.Tools.PdfTemplating.Models;

namespace Inoxie.Tools.PdfTemplating.Interfaces;

public interface IPdfTemplateConfigurationProvider<TTemplateModel>
    where TTemplateModel : BaseTemplateModel
{
    string TemplateUri { get; }
}
