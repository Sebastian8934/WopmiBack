using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Application.Services;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
            var transaction = await _service.GetAllTransactionItemAsync();
            return Ok(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TransactionItem transactionItem)
        {
            await _service.AddTransactionItemAsync(transactionItem);
            return Ok();
        }
    }
}
