using Domain.Entities;

namespace Domain.Ports
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(Product product);
    }
}
