using Domain.Entities;
using Domain.Ports;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories 
{
    public class CreditCardRepository : ICreditCardRepository
    {
        private readonly AppDbContext _context;

        public CreditCardRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CreditCard>> GetAllAsync()
        {            
            return await _context.CreditCard.ToListAsync();
        }

        public async Task AddAsync(CreditCard product)
        {
            _context.CreditCard.Add(product);
            await _context.SaveChangesAsync();
        }
    }
}
