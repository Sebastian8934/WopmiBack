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
    public class DeliveryInfoRepository : IDeliveryInfoRepository
    {
        private readonly AppDbContext _context;

        public DeliveryInfoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DeliveryInfo>> GetAllAsync()
        {            
            return await _context.DeliveryInfo.ToListAsync();
        }

        public async Task AddAsync(DeliveryInfo info)
        {
            _context.DeliveryInfo.Add(info);
            await _context.SaveChangesAsync();
        }
    }
}
