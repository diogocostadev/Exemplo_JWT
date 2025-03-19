using Exemplo_JWT.Models;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Exemplo_JWT.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }

    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            // Cria as claims do usuário
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };

            // Obtém a chave secreta dos configurations
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? "chave_secreta_padrao_insegura"));

            // Cria as credenciais de assinatura
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Cria o token
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1), // Token expira em 1 hora
                signingCredentials: creds
            );

            // Retorna o token em formato string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
