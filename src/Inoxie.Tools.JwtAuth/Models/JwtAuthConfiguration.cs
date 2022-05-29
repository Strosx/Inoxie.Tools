namespace Inoxie.Tools.JwtAuth.Models;

public class JwtAuthConfiguration
{
    public const string Key = "AuthConfiguration";

    public string AppSecret { get; set; }
    public int TokenExpirationInSeconds { get; set; }
}
