using Domain.Entities;
using Domain.Ports;

namespace Application.Services
{
    public class CreditCardsService
    {
        private readonly ICreditCardRepository _repository;

        public CreditCardsService(ICreditCardRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CreditCard>> GetAllCreditCardAsync() => await _repository.GetAllAsync();

        public async Task AddCreditCardAsync(CreditCard creditCard) => await _repository.AddAsync(creditCard);
    }
}
