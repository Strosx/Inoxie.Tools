using Inoxie.Tools.Excel.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inoxie.Tools.Example.Api.Controllers.Excel;

[Route("api/excel")]
public class ExcelController : ControllerBase
{
    private readonly ISpreadsheetBuilder _builder;

    public ExcelController(ISpreadsheetBuilder builder)
    {
        _builder = builder;
    }

    [HttpGet]
    public FileStreamResult GetTestExcel()
    {
        var stream = _builder.Create()
            .CreateSheet("test")
            .CreateHeaderRow("test", new string[] { "String value", "Numeric value", "Boolean value" })
            .InsertRowData("test", new object[] { "test", 123.45, true })
            .InsertEmptyRow("test")
            .InsertRowData("test", new object[] { "test 2 ", 23.45, false })
            .WriteToStream();

        return new FileStreamResult(stream, "application/ms-excel") { FileDownloadName = "test.xlsx" };
    }
}
