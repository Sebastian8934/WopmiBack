using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Domain.Entities;
using WebApi.shared;
using WebApi.Models.Requests.Transaction;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _service;
        private readonly TransactionItemService _TransactionItemService;
        private readonly ProductService _ProductService;

        public TransactionController(TransactionService service, TransactionItemService transactionItemService, ProductService productService)
        {
            _service = service;
            _TransactionItemService = transactionItemService;
            _ProductService = productService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var transactions = await _service.GetAllTransactionAsync();
                return Ok(new ApiResponse<object>(200, true, "Lista de transacciones", transactions));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<object>(500, false, "Error interno del servidor", ex.Message));
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TransactionRequest dto)
        {
            try
            {
                //Crea la transacción
                var transaction = new Transaction
                {
                    //UserId = dto.UserId,
                    TransactionNumber = dto.TransactionNumber,
                    Status = dto.Status,
                    TotalAmount = dto.TotalAmount,
                    BaseFee = dto.BaseFee,
                    DeliveryFee = dto.DeliveryFee
                };
                var resultTrasaction = await _service.AddTransactionAsync(transaction);

                if (resultTrasaction == null)
                {
                    return BadRequest(new ApiResponse<object>(400, false, "No se pudo guardar la transacción"));
                }

                //Crea a trasaccion item
                var transactionItem = new TransactionItem
                {
                    TransactionId = resultTrasaction.Id,
                    ProductId = dto.ProductId,
                    Quantity = dto.Quantity,
                    UnitPrice = dto.UnitPrice
                };
                var resultTrasactionItem = await _TransactionItemService.AddTransactionItemAsync(transactionItem);

                if (resultTrasactionItem == null)
                {
                    return BadRequest(new ApiResponse<object>(400, false, "No se pudo guardar el detalle de la transacción"));
                }

                //Actualiza el stock del producto
                await _ProductService.DecreaseStockAsync(dto.ProductId, dto.StockQuantity);

                //Retorna la respuesta
                return Ok(new ApiResponse<object>(200, true, "Venta realizada con exito"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<object>(500, false, "Error interno del servidor", ex.Message));
            }
        }

    }
}
