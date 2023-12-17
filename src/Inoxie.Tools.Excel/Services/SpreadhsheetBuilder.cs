using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Inoxie.Tools.Excel.Interfaces;
using Inoxie.Tools.Excel.Models;

namespace Inoxie.Tools.Spreadsheet.Services;

internal class SpreadsheetBuilder : ISpreadsheetBuilder
{
    private IWorkbook _workbook;
    private Dictionary<string, int> _sheetRows = new();

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
        foreach (var dataRow in dataRows)
            InsertRowData(sheetName, dataRow);

        return this;
    }

    public ISpreadsheetBuilder InsertRowData(string sheetName, object[] dataRow)
    {
        var sheet = _workbook.GetSheet(sheetName);
        var rowNumber = GetNextRowNumber(sheetName);
        var row = sheet.CreateRow(rowNumber);
        int columnIndex = 0;

        foreach (var data in dataRow)
        {
            var value = data?.ToString();
            if (string.IsNullOrWhiteSpace(value))     
                value = " ";

            var cell = row.CreateCell(columnIndex);

            if (double.TryParse(value, out var numericValue))
            {
                cell.SetCellType(CellType.Numeric);
                cell.SetCellValue(numericValue);
            }
            else if (bool.TryParse(value, out var boolValue))
            {
                cell.SetCellType(CellType.Boolean);
                cell.SetCellValue(boolValue);
            }
            else
            {
                cell.SetCellType(CellType.String);
                cell.SetCellValue(value);
            }

            columnIndex++;
        }

        return this;
    }

    public ISpreadsheetBuilder InsertEmptyRow(string sheetName)
    {
        var sheet = _workbook.GetSheet(sheetName);
        var rowNumber = GetNextRowNumber(sheetName);
        sheet.SetRowBreak(rowNumber);

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

    private int GetNextRowNumber(string sheetName)
    {
        if (_sheetRows.TryGetValue(sheetName, out var rowNumber))
        {
            _sheetRows[sheetName] = ++rowNumber;
            return _sheetRows[sheetName];
        }

        _sheetRows.Add(sheetName, 1);
        return 1;
    }
}