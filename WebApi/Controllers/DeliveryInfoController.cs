using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Application.Services;
using Domain.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryInfoController : ControllerBase
    {
        private readonly DeliveryInfoService _service;

        public DeliveryInfoController(DeliveryInfoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAllDeliveryInfodAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(DeliveryInfo product)
        {
            await _service.AddDeliveryInfoAsync(product);
            return Ok();
        }
    }
}
