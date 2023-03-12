
using AutoMapper;
using CleanStore.Application.Contracts.Persistence;
using CleanStore.Application.Exceptions;
using CleanStore.Application.Features.Sellers.Commands.UpdateSeller;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanStore.Application.Features.Sellers.Commands.DeleteSeller
{
    public class DeleteSellerCommandHandler : IRequestHandler<DeleteSellerCommand, Unit>
    {

        private readonly ISellerRepository _sellerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteSellerCommandHandler> _logger;

        public DeleteSellerCommandHandler(ISellerRepository sellerRepository, IMapper mapper, ILogger<DeleteSellerCommandHandler> logger)
        {
            _sellerRepository = sellerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteSellerCommand request, CancellationToken cancellationToken)
        {
            var sellerToDelete = await _sellerRepository.GetByIdAsync(request.Id);
            if (sellerToDelete == null)
            {
                _logger.LogError($"Seller {request.Id} not found");
                throw new NotFoundException(nameof(UpdateSellerCommandHandler), request.Id);
            }
            await _sellerRepository.DeleteAsync(sellerToDelete);
            _logger.LogInformation($"Delete was successfully completed {request.Id}");
            return Unit.Value;
        }
    }
}
