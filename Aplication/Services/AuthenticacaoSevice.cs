using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Teste_Tecnico.Aplication.Interfaces;

namespace Teste_Tecnico.Aplication.Services
{
    public class AuthenticacaoSevice : IAuthenticacaoService
    {
        private readonly IConfiguration _configuration;

        public AuthenticacaoSevice(IConfiguration config)
        {
            _configuration = config;
        }

        public string Authenticacao(string email, string senha, string hash)
        {
            try
            {
                bool senhaValida = BCrypt.Net.BCrypt.Verify(senha, hash);

                if (!senhaValida)
                    throw new Exception("Senha inválida!");

                var secretKey = _configuration["Jwt:Key"];
                var issuer = _configuration["Jwt:Issuer"];
                var audience = _configuration["Jwt:Audience"];

                var claims = new[]
                {
                new Claim(ClaimTypes.Name,email),
                new Claim(ClaimTypes.Name,"Usuario"),
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));

                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                   issuer: issuer,
                   audience: audience,
                   claims: claims,
                   expires: DateTime.UtcNow.AddHours(1),
                   signingCredentials: credentials
                 );

                string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return tokenString;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
