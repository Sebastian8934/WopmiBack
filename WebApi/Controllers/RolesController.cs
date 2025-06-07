using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _service;

        public RolesController(IRoleService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromQuery] string name)
        {
            var result = await _service.CreateAsync(name);
            return result ? Ok("Rol creado") : BadRequest("El rol ya existe");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _service.GetAllAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var role = await _service.GetByIdAsync(id);
            return role != null ? Ok(role) : NotFound("Rol no encontrado");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromQuery] string name)
        {
            var updated = await _service.UpdateAsync(id, name);
            return updated ? Ok("Rol actualizado") : NotFound("Rol no encontrado");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? Ok("Rol eliminado") : NotFound("Rol no encontrado");
        }
    }
}
