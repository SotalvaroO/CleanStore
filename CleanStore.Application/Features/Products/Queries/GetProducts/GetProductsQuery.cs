
using MediatR;

namespace CleanStore.Application.Features.Products.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<List<ProductsVm>>
    {
        public string Username { get; set; } =string.Empty;
        public GetProductsQuery(string? username)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
        }
    }
}
