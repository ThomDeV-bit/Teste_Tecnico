using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Teste_Tecnico.Api.Middlewares
{
    public static class JwtServiceMiddleware
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services , IConfiguration configuration)
        {
            string issuer = configuration["Jwt:Issuer"]!;

            string audience = configuration["Jwt:Audience"]!;

            string secretKey = configuration["Jwt:key"]!;

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                    };
                });

            return services;
        }
    }
}
