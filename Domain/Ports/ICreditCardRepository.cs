using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports
{
    public interface ICreditCardRepository
    {
        Task<IEnumerable<CreditCard>> GetAllAsync();
        Task AddAsync(CreditCard product);
    }
}
