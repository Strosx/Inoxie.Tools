using Inoxie.Tools.PdfTemplating.Models;
using System.IO;
using System.Threading.Tasks;

namespace Inoxie.Tools.PdfTemplating.Interfaces;

public interface IPdfGenerator<TTemplateModel>
    where TTemplateModel : BaseTemplateModel
{
    Task<Stream> GenerateAsync(TTemplateModel model);
}
