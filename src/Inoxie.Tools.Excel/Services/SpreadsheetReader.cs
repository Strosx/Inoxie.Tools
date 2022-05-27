using Inoxie.Tools.Excel.Interfaces;
using NPOI.XSSF.UserModel;

namespace Inoxie.Tools.Excel.Services;

internal class SpreadsheetReader : ISpreadsheetReader
{
    public List<(string name, IEnumerable<IEnumerable<string>> data)> Read(Stream stream)
    {
        var workbook = new XSSFWorkbook(stream);
        var numberOfSheets = workbook.NumberOfSheets;
        var workbookData = new List<(string name, IEnumerable<IEnumerable<string>> data)>();
        for (int i = 0; i < numberOfSheets; i++)
        {
            var sheet = workbook.GetSheetAt(i);

            var sheetName = sheet.SheetName;
            var lastRowNumber = sheet.LastRowNum;

            var sheetData = new List<IEnumerable<string>>();
            for (int j = 1; j <= lastRowNumber; j++)
            {
                var row = sheet.GetRow(j);
                var lastCellNumber = row.LastCellNum;

                var rowData = new List<string>();
                for (int h = 0; h < lastCellNumber; h++)
                {
                    var cell = row.GetCell(h);
                    var cellValue = "";
                    try
                    {
                        cellValue = cell.StringCellValue;
                    }
                    catch (System.Exception)
                    {
                        cellValue = cell.NumericCellValue.ToString();
                    }
                    rowData.Add(cellValue);
                }

                sheetData.Add(rowData);
            }

            workbookData.Add((sheetName, sheetData));
        }

        return workbookData;
    }
}
