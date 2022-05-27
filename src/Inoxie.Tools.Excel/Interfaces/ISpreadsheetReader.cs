namespace Inoxie.Tools.Excel.Interfaces;

public interface ISpreadsheetReader
{
    List<(string name, IEnumerable<IEnumerable<string>> data)> Read(Stream stream);
}
