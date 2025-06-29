using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Domain.Entities;
using WebApi.shared;
using WebApi.Models.Requests.Transaction;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _service;
        private readonly TransactionItemService _TransactionItemService;

        public TransactionController(TransactionService service, TransactionItemService transactionItemService)
        {
            _service = service;
            _TransactionItemService = transactionItemService;
        }

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

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TransactionRequest dto)
        {
            try
            {
                //Debe crear a transaction
                //Debe crear el registro de trasaction item 
                //Debe descontar el producto
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


                //var transactionItem = new TransactionItem
                //{
                //    Quantity = dto.Quantity,
                //    UnitPrice = dto.UnitPrice
                //};
                //await _TransactionItemService.AddTransactionItemAsync(transactionItem);

                return Ok(new ApiResponse<object>(200, true, "Venta realizada con exito"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<object>(500, false, "Error interno del servidor", ex.Message));
            }
        }

    }
}
