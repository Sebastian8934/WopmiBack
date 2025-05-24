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
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _service;
        private readonly AppDbContext _context;

        public CustomerController(CustomerService service, AppDbContext context)
        {
            _service = service;
            _context = context;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var products = await _service.GetAllCustomerAsync();
        //    return Ok(products);
        //}

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _context.Customer
            .Include(c => c.CreditCard)
            .Include(c => c.DeliveryInfo)
            .Include(c => c.Transaction)
            .Select(c => new
            {
                c.Id,
                c.FullName,
                c.Email,
                c.PhoneNumber,
                CreditCards = c.CreditCard.Select(cc => new
                {
                    cc.Id,
                    cc.CardholderName,
                    cc.ExpirationDate
                }),
                DeliveryInfos = c.DeliveryInfo.Select(di => new
                {
                    di.Id,
                    di.Address,
                    di.City,
                    di.State,
                    di.ZipCode,
                    di.Country
                }),
                Transactions = c.Transaction.Select(ei => new
                {
                    ei.Id,
                    ei.TransactionNumber,
                    ei.Status,
                    ei.TotalAmount,
                    ei.BaseFee,
                    ei.DeliveryFee,
                }),
            }).ToListAsync();

            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Customer product)
        {
            await _service.AddCustomertAsync(product);
            return Ok();
        }
    }
}
