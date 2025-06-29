using Domain.Entities;

namespace Domain.Ports
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(Product product);
        Task AddMultipleAsync(List<Product> product);
        //Task <int> GetByIdAsync(int ProductId);
        Task DecreaseStockAsync(int ProductId, int StockQuantity);
    }
}
