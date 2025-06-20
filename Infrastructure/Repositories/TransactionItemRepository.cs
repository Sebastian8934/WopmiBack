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
    public class TransactionItemRepository : ITransactionItemRepository
    {
        private readonly AppDbContext _context;

        public TransactionItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TransactionItem>> GetAllAsync()
        {
            return await _context.TransactionItem.ToListAsync();             
        }

        public async Task AddAsync(TransactionItem transactionItem)
        {
            _context.TransactionItem.Add(transactionItem);
            await _context.SaveChangesAsync();
        }
    }
}
