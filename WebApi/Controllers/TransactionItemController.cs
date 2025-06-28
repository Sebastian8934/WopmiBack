using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Domain.Entities;
using WebApi.shared;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionItemController : ControllerBase
    {
        private readonly TransactionItemService _service;

        public TransactionItemController(TransactionItemService servicio)
        {
            _service = servicio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var transaction = await _service.GetAllTransactionItemAsync();
                return Ok(transaction);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<object>(500, false, "Error interno del servidor", ex.Message));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(TransactionItem transactionItem)
        {
            try
            {
                await _service.AddTransactionItemAsync(transactionItem);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<object>(500, false, "Error interno del servidor", ex.Message));
            }
        }
    }
}
