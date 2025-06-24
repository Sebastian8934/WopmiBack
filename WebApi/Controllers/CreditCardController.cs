using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Domain.Entities;

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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllCreditCardAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreditCard product)
        {
            await _service.AddCreditCardAsync(product);
            return Ok();
        }
    }
}
