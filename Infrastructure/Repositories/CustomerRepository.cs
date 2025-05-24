using Domain.Entities;
using Domain.Ports;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;


namespace Infrastructure.Repositories 
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
           return await _context.Customer.Include(a => a.CreditCard).ToListAsync();
        }

        public async Task AddAsync(Customer customer)
        {
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();
        }
    }
}
