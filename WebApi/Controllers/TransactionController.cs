using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Domain.Entities;
using WebApi.shared;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _service;

        public TransactionController(TransactionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var transaction = await _service.GetAllTransactionAsync();
                return Ok(transaction);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<object>(500, false, "Error interno del servidor", ex.Message));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Transaction transaction)
        {
            try
            {
                await _service.AddTransactionAsync(transaction);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<object>(500, false, "Error interno del servidor", ex.Message));
            }
        }
    }
}
