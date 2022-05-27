using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Inoxie.Tools.Excel.Interfaces;
using Inoxie.Tools.Excel.Models;

namespace Inoxie.Tools.Spreadsheet.Services;

internal class SpreadsheetBuilder : ISpreadsheetBuilder
{
    private IWorkbook _workbook;

    public ISpreadsheetBuilder Create()
    {
        _workbook = new XSSFWorkbook();
        return this;
    }

    public ISpreadsheetBuilder CreateSheet(string sheetName)
    {
        _workbook.CreateSheet(sheetName);
        return this;
    }

    public ISpreadsheetBuilder CreateHeaderRow(string sheetName, string[] headers)
    {
        var sheet = _workbook.GetSheet(sheetName);

        var row = sheet.CreateRow(0);
        int columnIndex = 0;

        foreach (var header in headers)
        {
            row.CreateCell(columnIndex).SetCellValue(header);
            columnIndex++;
        }

        return this;
    }

    public ISpreadsheetBuilder InsertRowData(string sheetName, IEnumerable<object[]> dataRows)
    {
        var rowNumber = 1;
        var sheet = _workbook.GetSheet(sheetName);

        foreach (var dataRow in dataRows)
        {
            var row = sheet.CreateRow(rowNumber);
            int columnIndex = 0;
            foreach (var data in dataRow)
            {
                var value = data?.ToString();
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = " ";
                }

                row.CreateCell(columnIndex).SetCellValue(value);
                columnIndex++;
            }

            rowNumber++;
        }
        return this;
    }

    public NpoiMemoryStream WriteToStream()
    {
        var stream = new NpoiMemoryStream
        {
            AllowClose = false
        };
        _workbook.Write(stream);
        stream.Flush();
        stream.Seek(0, SeekOrigin.Begin);
        stream.AllowClose = true;

        return stream;
    }

}
