using Domain.Entities;

namespace Domain.Ports
{
    public interface ICreditCardRepository
    {
        Task<IEnumerable<CreditCard>> GetAllAsync();
        Task AddAsync(CreditCard creditCard);
    }
}
