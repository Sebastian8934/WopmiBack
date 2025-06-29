using Domain.Entities;
using Domain.Ports;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories 
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Product.ToListAsync();             
        }

        public async Task AddAsync(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task AddMultipleAsync(List<Product> products)
        {
            _context.Product.AddRange(products);
            await _context.SaveChangesAsync();
        }
        //public async Task<Product> GetByIdAsync(int ProductId)
        //{
        //   return await _context.Product.FindAsync(ProductId);
        //}

        public async Task DecreaseStockAsync(int productId, int stockQuantity)
        {
            var product = await _context.Product.FindAsync(productId);

            if (product == null)
                throw new Exception("Producto no encontrado");

            if (product.StockQuantity < stockQuantity)
                throw new Exception("Stock insuficiente");

            product.StockQuantity -= stockQuantity;

            _context.Product.Update(product);
            await _context.SaveChangesAsync();
        }

    }
}
