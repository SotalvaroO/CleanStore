
using MediatR;

namespace CleanStore.Application.Features.Sellers.Commands.DeleteSeller
{
    public class DeleteSellerCommand: IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
