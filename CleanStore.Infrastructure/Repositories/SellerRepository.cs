
using CleanStore.Application.Contracts.Persistence;
using CleanStore.Domain.Models;
using CleanStore.Infrastructure.Context;

namespace CleanStore.Infrastructure.Repositories
{
    public class SellerRepository : BaseRepository<Seller, int>, ISellerRepository
    {
        public SellerRepository(StoreDbContext context) : base(context)
        {
        }
    }
}
