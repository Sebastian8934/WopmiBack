using Domain.Entities;
using Domain.Ports;

namespace Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync() => await _repository.GetAllAsync();

        public async Task AddProductAsync(Product product) => await _repository.AddAsync(product);

        public async Task AddProductsAsync(List<Product> products)
        {
            await _repository.AddMultipleAsync(products);
        }

        //public Task Get

        public async Task DecreaseStockAsync(int productId,int stockQuantity)
        {           
            await _repository.DecreaseStockAsync(productId, stockQuantity);
        }
    }
}
