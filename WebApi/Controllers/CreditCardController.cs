using Microsoft.AspNetCore.Mvc;
using Application.Services;
using WebApi.shared;
using WebApi.Models.Requests.CreditCard;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly CreditCardsService _service;

        public CreditCardController(CreditCardsService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _service.GetAllCreditCardAsync();
                return Ok(new ApiResponse<object>(200, true, "Lista de productos", products));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<object>(500, false, "Error interno del servidor", ex.Message));
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreditCardRequest dto)
        {
            try
            {
                var creditCard = new CreditCard
                {
                    CardNumber = dto.CardNumber,
                    CardholderName = dto.CardholderName,
                    ExpirationDate = dto.ExpirationDate,
                    Cvv = dto.Cvv
                };

                await _service.AddCreditCardAsync(creditCard);
                return Ok(new ApiResponse<object>(200, true, "tarjeta agregada correctamente"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<object>(500, false, "Error interno del servidor", ex.Message));
            }
        }
    }
}
