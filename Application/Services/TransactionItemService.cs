using Domain.Entities;
using Domain.Ports;

namespace Application.Services
{
    public class TransactionItemService
    {
        private readonly ITransactionItemRepository _repository;

        public TransactionItemService(ITransactionItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TransactionItem>> GetAllTransactionItemAsync() => await _repository.GetAllAsync();

        public async Task AddTransactionItemAsync(TransactionItem transactionItem) => await _repository.AddAsync(transactionItem);
    }
}
