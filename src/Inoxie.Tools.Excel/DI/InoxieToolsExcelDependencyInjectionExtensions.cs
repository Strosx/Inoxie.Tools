using Inoxie.Tools.Excel.Interfaces;
using Inoxie.Tools.Excel.Services;
using Inoxie.Tools.Spreadsheet.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Inoxie.Tools.Excel.DI;

public static class InoxieToolsExcelDependencyInjectionExtensions
{
    public static IServiceCollection AddInoxieToolsExcel(this IServiceCollection services)
    {
        services.AddScoped<ISpreadsheetBuilder, SpreadsheetBuilder>();
        services.AddScoped<ISpreadsheetReader, SpreadsheetReader>();
        return services;
    }
}
