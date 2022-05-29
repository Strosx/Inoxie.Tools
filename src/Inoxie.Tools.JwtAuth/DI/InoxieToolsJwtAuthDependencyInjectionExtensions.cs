using Inoxie.Tools.JwtAuth.Controllers;
using Inoxie.Tools.JwtAuth.Interfaces;
using Inoxie.Tools.JwtAuth.Models;
using Inoxie.Tools.JwtAuth.Services;
using Inoxie.Tools.JwtAuth.Services.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Inoxie.Tools.JwtAuth.DI;

public static class InoxieToolsJwtAuthDependencyInjectionExtensions
{
    public static void AddInoxieJwtAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMvc()
            .PartManager.ApplicationParts.Add(new AssemblyPart(typeof(AuthController).Assembly));

        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IRefreshTokenService, RefreshTokenService>();
        services.AddScoped<RefreshTokenGenerator>();
        services.AddScoped<JwtTokenGenerator>();

        services.Configure<JwtAuthConfiguration>(options =>
            configuration.GetSection(JwtAuthConfiguration.Key).Bind(options));

        var key = Encoding.ASCII.GetBytes(configuration.GetValue<string>($"{JwtAuthConfiguration.Key}:{nameof(JwtAuthConfiguration.AppSecret)}"));
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.IncludeErrorDetails = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
    }

    public static void UseInoxieJwtAuth(this IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}
