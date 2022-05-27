using Inoxie.Tools.Excel.Models;

namespace Inoxie.Tools.Excel.Interfaces;

public interface ISpreadsheetBuilder
{
    ISpreadsheetBuilder Create();
    ISpreadsheetBuilder CreateSheet(string sheetName);
    ISpreadsheetBuilder CreateHeaderRow(string sheetName, string[] headers);
    ISpreadsheetBuilder InsertRowData(string sheetName, IEnumerable<object[]> dataRows);
    NpoiMemoryStream WriteToStream();

}
