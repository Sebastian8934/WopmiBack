using Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/users/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return user == null ? NotFound("Usuario no encontrado") : Ok(user);
        }

        // GET: api/users/email?email=correo@ejemplo.com
        [HttpGet("email")]
        public async Task<IActionResult> GetByEmail([FromQuery] string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            return user == null ? NotFound("Usuario no encontrado") : Ok(user);
        }

        // GET: api/users
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        // PUT: api/users/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFullName(string id, [FromBody] UpdateUserNameRequest request)
        {
            var updated = await _userService.UpdateFullNameAsync(id, request.FullName);
            return updated ? Ok("Nombre actualizado correctamente") : NotFound("Usuario no encontrado");
        }

        // DELETE: api/users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _userService.DeleteUserAsync(id);
            return deleted ? Ok("Usuario eliminado correctamente") : NotFound("Usuario no encontrado");
        }

        // DTO solo para actualizar el nombre
        public class UpdateUserNameRequest
        {
            public string FullName { get; set; } = default!;
        }
    }
}
