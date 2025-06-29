using Domain.Entities;

namespace Domain.Ports
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetAllAsync();
        Task<Transaction> AddAsync(Transaction transaction);
    }
}
