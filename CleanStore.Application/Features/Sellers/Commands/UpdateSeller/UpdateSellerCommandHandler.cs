
using AutoMapper;
using CleanStore.Application.Contracts.Persistence;
using CleanStore.Application.Exceptions;
using CleanStore.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanStore.Application.Features.Sellers.Commands.UpdateSeller
{
    public class UpdateSellerCommandHandler : IRequestHandler<UpdateSellerCommand, Unit>
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateSellerCommandHandler> _logger;

        public UpdateSellerCommandHandler(ISellerRepository sellerRepository, IMapper mapper, ILogger<UpdateSellerCommandHandler> logger)
        {
            _sellerRepository = sellerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateSellerCommand request, CancellationToken cancellationToken)
        {
            var sellerToUpdate = await _sellerRepository.GetByIdAsync(request.Id);
            if (sellerToUpdate == null)
            {
                _logger.LogError($"Seller {request.Id} not found");
                throw new NotFoundException(nameof(UpdateSellerCommandHandler), request.Id);
            }
            _mapper.Map(request, sellerToUpdate, typeof(UpdateSellerCommand), typeof(Seller));
            await _sellerRepository.UpdateAsync(request.Id, sellerToUpdate);
            _logger.LogInformation($"Update was successfully completed {request.Id}");
            return Unit.Value;
        }
    }
}
