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
        private readonly CustomerService _service;
        private readonly AppDbContext _context;

        public TransactionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var transaction = await _context.Transaction.ToListAsync();
            return Ok(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Transaction transaction)
        {
            await _context.Transaction.AddAsync(transaction);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
