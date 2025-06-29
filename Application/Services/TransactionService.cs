using Domain.Entities;
using Domain.Ports;

namespace Application.Services
{
    public class TransactionService
    {
        private readonly ITransactionRepository _repository;

        public TransactionService(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionAsync() => await _repository.GetAllAsync();

        public async Task<Transaction> AddTransactionAsync(Transaction transaction) => await _repository.AddAsync(transaction);
    }
}
