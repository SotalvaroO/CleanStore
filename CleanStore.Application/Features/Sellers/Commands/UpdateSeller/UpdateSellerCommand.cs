
using MediatR;

namespace CleanStore.Application.Features.Sellers.Commands.UpdateSeller
{
    public class UpdateSellerCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
