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
            var transaction = await _service.GetAllTransactionAsync();
            return Ok(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Transaction transaction)
        {
            await _service.AddTransactionAsync(transaction);
            return Ok();
        }
    }
}
