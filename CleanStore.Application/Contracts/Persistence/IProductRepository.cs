
using CleanStore.Domain.Models;

namespace CleanStore.Application.Contracts.Persistence
{
    public interface IProductRepository : IAsyncRepository<Product, int>  //TODO: obtener el tipo del id mediante el base domain
    {
        Task<Product> GetProductBySku(string productSku);

        Task<IEnumerable<Product>> GetProductByUsername(string username);
    }
}
