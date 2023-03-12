
using CleanStore.Domain.Models;

namespace CleanStore.Application.Contracts.Persistence
{
    public interface ISellerRepository: IAsyncRepository<Seller,int>
    {
    }
}
