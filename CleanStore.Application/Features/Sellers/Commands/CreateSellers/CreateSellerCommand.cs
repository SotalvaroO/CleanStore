
using MediatR;

namespace CleanStore.Application.Features.Sellers.Commands.CreateSellers
{
    public class CreateSellerCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
