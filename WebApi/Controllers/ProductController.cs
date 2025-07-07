using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Domain.Entities;
using WebApi.shared;
using WebApi.Models.Requests.Product;
using WebApi.Models.Responses.Product;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _service.GetAllProductsAsync();
                return Ok(new ApiResponse<object>(200, true, "Lista de productos",products));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<object>(500, false, "Error interno del servidor", ex.Message));
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductRequest dto)
        {
            try
            {
                var product = new Product
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    Price = dto.Price,
                    StockQuantity = dto.StockQuantity
                };

                await _service.AddProductAsync(product);
                return Ok(new ApiResponse<object>(200, true, "Producto agregado correctamente"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<object>(500, false, "Error interno del servidor", ex.Message));
            }
        }

        [Authorize]
        [HttpPost("bulk")]
        public async Task<IActionResult> AddMultiple([FromBody] List<ProductResponse> dtoList)
        {
            try
            {
                var products = dtoList.Select(dto => new Product
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    Price = dto.Price,
                    StockQuantity = dto.StockQuantity
                }).ToList();

                await _service.AddProductsAsync(products);
                return Ok(new ApiResponse<object>(200, true, "Productos agregados correctamente"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<object>(500, false, "Error interno del servidor", ex.Message));
            }
        }
    }
}
