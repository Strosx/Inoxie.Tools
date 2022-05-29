namespace Inoxie.Tools.JwtAuth.Models.Domain;

public class AuthenticationOutDto
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public DateTime ExpirationDate { get; set; }
}
