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
        private readonly CustomerService _service;
        private readonly AppDbContext _context;

        public TransactionItemController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var transaction = await _context.TransactionItem.ToListAsync();
            return Ok(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TransactionItem transactionItem)
        {
            await _context.TransactionItem.AddAsync(transactionItem);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
