using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Application.Interface;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly UserManager<AppUser> _userManager;

        public AuthController(UserManager<AppUser> userManager, IAuthService authService)
        {
            _authService = authService;
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                return Unauthorized("Credenciales inválidas");

            var token = await _authService.GenerateToken(user.Id);
            return Ok(new { token });
        }

        [Authorize]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {
            Console.WriteLine(model);
            var result = await _authService.RegisterAsync(model.email, model.password);
            if (!result.Succeeded) return BadRequest(result.Errors);

            return Ok("Usuario registrado correctamente");
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return Ok("Sesión cerrada correctamente");
        }

        public class LoginRequest
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class RegisterRequest
        {
            public string email { get; set; }
            public string password { get; set; }
            public string nombreCompleto { get; set; }
        }


    }
}
