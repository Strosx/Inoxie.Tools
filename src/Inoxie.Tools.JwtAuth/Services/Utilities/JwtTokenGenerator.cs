using Inoxie.Tools.JwtAuth.Models;
using Inoxie.Tools.JwtAuth.Models.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Inoxie.Tools.JwtAuth.Services.Utilities;

internal class JwtTokenGenerator
{
    private readonly IOptions<JwtAuthConfiguration> options;

    public JwtTokenGenerator(IOptions<JwtAuthConfiguration> options)
    {
        this.options = options;
    }

    public string GenerateJwtToken(AccountEntity account)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(options.Value.AppSecret);

        var claims = account.Roles.Select(role => new Claim(ClaimTypes.Role, role.Role.Name)).ToList();
        claims.Add(new Claim(ClaimTypes.NameIdentifier, account.Username));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddSeconds(options.Value.TokenExpirationInSeconds),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

}
