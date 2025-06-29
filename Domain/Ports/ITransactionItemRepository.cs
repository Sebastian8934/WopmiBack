using Domain.Entities;

namespace Domain.Ports
{
    public interface ITransactionItemRepository
    {
        Task<IEnumerable<TransactionItem>> GetAllAsync();
        Task<TransactionItem> AddAsync(TransactionItem transactionItem);
    }
}
