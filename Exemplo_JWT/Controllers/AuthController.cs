using Exemplo_JWT.Models;
using Exemplo_JWT.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exemplo_JWT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public AuthController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Verifica se as credenciais são válidas
            var user = _userService.Authenticate(request.Username, request.Password);

            if (user == null)
                return Unauthorized(new { message = "Credenciais inválidas" });

            // Gera o token JWT
            var token = _jwtService.GenerateToken(user);

            // Retorna o token para o cliente
            return Ok(new { token });
        }

        [HttpGet("profile")]
        [Authorize(Policy = "UserAccess")]
        public IActionResult GetProfile()
        {
            // Obtém o usuário atual a partir do token
            var username = User.Identity?.Name;
            var user = _userService.GetByUsername(username ?? "");

            if (user == null)
                return NotFound(new { message = "Usuário não encontrado" });

            return Ok(new
            {
                message = "Rota protegida acessada com sucesso",
                user = new
                {
                    user.Id,
                    user.Username,
                    user.Role
                }
            });
        }

        [HttpGet("admin")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult GetAdmin()
        {
            // Obtém o usuário atual a partir do token
            var username = User.Identity?.Name;
            var user = _userService.GetByUsername(username ?? "");

            if (user == null)
                return NotFound(new { message = "Usuário não encontrado" });

            return Ok(new
            {
                message = "Área de admin acessada com sucesso",
                user = new
                {
                    user.Id,
                    user.Username,
                    user.Role
                }
            });
        }
    }
}
