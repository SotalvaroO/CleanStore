
using AutoMapper;
using CleanStore.Application.Contracts.Infrastructure;
using CleanStore.Application.Contracts.Persistence;
using CleanStore.Application.Models;
using CleanStore.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanStore.Application.Features.Sellers.Commands.CreateSellers
{
    public class CreateSellerCommandHandler : IRequestHandler<CreateSellerCommand, int>
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateSellerCommandHandler> _logger;

        public CreateSellerCommandHandler(ISellerRepository sellerRepository, IMapper mapper, IEmailService emailService, ILogger<CreateSellerCommandHandler> logger)
        {
            _sellerRepository = sellerRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateSellerCommand request, CancellationToken cancellationToken)
        {
            var seller = _mapper.Map<Seller>(request);
            var newSeller = await _sellerRepository.AddAsync(seller);
            _logger.LogInformation($"Seller {newSeller.Id} created successfully");
            await SendEmail(newSeller);
            return newSeller.Id;
        }

        private async Task SendEmail(Seller seller)
        {
            Email email = new()
            {
                To = "mudquip1997@gmail.com",
                Body = "El seller se creó correctamente",
                Subject = "Mensaje de alerta"
            };
            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Errores enviando el email de {seller.Id}. {ex.Message}");
                throw;
            }
        }
    }
}
