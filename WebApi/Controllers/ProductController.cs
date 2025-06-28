using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Domain.Entities;
using Application.DTOs.Requests.Product;
using WebApi.shared;

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

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductResponseDto dto)
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

        [HttpPost("bulk")]
        public async Task<IActionResult> AddMultiple([FromBody] List<ProductResponseDto> dtoList)
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
