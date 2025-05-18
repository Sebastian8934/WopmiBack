using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Domain.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _service;

        public CustomerController(CustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllCustomerAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Customer product)
        {
            await _service.AddCustomertAsync(product);
            return Ok();
        }
    }
}
