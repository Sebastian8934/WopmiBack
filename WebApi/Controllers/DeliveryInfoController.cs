using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Application.Services;
using Domain.Entities;
using WebApi.Models.Requests.DeliveryInfo;
using WebApi.shared;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var deliverys = await _service.GetAllDeliveryInfodAsync();
                return Ok(new ApiResponse<object>(200, true, "Lista de informacion", deliverys));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<object>(500, false, "Error interno del servidor", ex.Message));
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] DeliveryInfoRequest dto)
        {
            try
            {
                var deliveryInfo = new DeliveryInfo
                {
                    Address = dto.Address,
                    City = dto.City,
                    State = dto.State,
                    ZipCode = dto.ZipCode,
                    Country = dto.Country
                };
                await _service.AddDeliveryInfoAsync(deliveryInfo);
                return Ok(new ApiResponse<object>(200, true, "Se creo correctamente"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<object>(500, false, "Error interno del servidor", ex.Message));
            }
        }
    }
}
