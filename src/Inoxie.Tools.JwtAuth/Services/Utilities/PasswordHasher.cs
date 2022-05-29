using System.Security.Cryptography;
using System.Text;

namespace Inoxie.Tools.JwtAuth.Services.Utilities;

public class PasswordHasher
{
    public static string Hash(string value)
    {
        using var sha256 = SHA256.Create();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(value));
        var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        return hash;
    }

}

