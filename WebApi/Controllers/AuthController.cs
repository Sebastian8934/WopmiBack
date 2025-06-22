using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Application.Interface;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using WebApi.Models.Responses;
using Application.DTOs;
using WebApi.Models.Responses.Auth;
using WebApi.Models.Requests.Auth;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(UserManager<AppUser> userManager, IAuthService authService,RoleManager<IdentityRole> roleManager)
        {
            _authService = authService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    return Unauthorized(new ApiResponse<object>(401, false, "Credenciales inválidas", null));
                }

                var roles = await _userManager.GetRolesAsync(user);
                var rol = roles.FirstOrDefault() ?? "SinRol";

                var token = await _authService.GenerateToken(user.Id);

                var response = new LoginResponse
                {
                    Token = token.token,
                    ExpiresIn = token.expiresIn
                };

                return Ok(new ApiResponse<LoginResponse>(200, true, "Inicio de sesión exitoso", response));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<object>(500, false, "Error interno del servidor", ex.Message));
            }
        }

        [Authorize]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {
            try
            {

                // 1. Validar si el rol existe
                if (!await _roleManager.RoleExistsAsync(model.Role))
                {
                    return BadRequest(new ApiErrorResponse(400, "ROLE_NOT_FOUND", $"El rol '{model.Role}' no existe."));
                }

                // 2. Crear el usuario desde el DTO
                var user = new AppUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    FullName = model.FullName
                };

                // 3. Crear usuario con Identity
                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    var error = result.Errors.FirstOrDefault()?.Description ?? "Error desconocido al registrar usuario.";
                    return BadRequest(new ApiErrorResponse(400, "USER_CREATION_FAILED", error));
                }

                // 4. Asignar el rol al usuario
                var roleResult = await _userManager.AddToRoleAsync(user, model.Role);

                if (!roleResult.Succeeded)
                {
                    return BadRequest(new ApiErrorResponse(400, "ROLE_ASSIGN_FAILED", "No se pudo asignar el rol."));
                }

                // 5. Devolver respuesta
                return Ok(new ApiResponse<object>(200, true, "Usuario registrado"));

            }

            catch (Exception ex)
            {
                // Error inesperado
                return StatusCode(500, new ApiErrorResponse(500, "INTERNAL_SERVER_ERROR", ex.Message));
            }

        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return Ok("Sesión cerrada correctamente");
        }

    }
}
