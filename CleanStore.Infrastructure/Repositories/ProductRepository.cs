
using CleanStore.Application.Contracts.Persistence;
using CleanStore.Domain.Models;
using CleanStore.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanStore.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product, int>, IProductRepository
    {
        public ProductRepository(StoreDbContext context) : base(context)
        {
        }

        public async Task<Product> GetProductBySku(string productSku)
        {
            return await _context.Products!.Where(p => p.ProductDetail!.Sku == productSku).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByUsername(string username)
        {
            return await _context.Products!.Where(p => p.CreatedBy == username).ToListAsync();
        }
    }
}
