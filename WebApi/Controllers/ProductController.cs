using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Application.Services;
using Domain.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            await _service.AddProductAsync(product);
            return Ok();
        }
    }
}
