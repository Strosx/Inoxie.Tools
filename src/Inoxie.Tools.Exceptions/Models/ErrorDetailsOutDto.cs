namespace Inoxie.Tools.Exceptions.Models;

internal class ErrorDetailsOutDto
{
    public int StatusCode { get; set; }
    public int? ErrorCode { get; set; }
    public string? Message { get; set; }
}
