using AutoMapper;
using CleanStore.Application.Contracts.Persistence;
using MediatR;

namespace CleanStore.Application.Features.Products.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductsVm>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductsVm>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var productList = await _productRepository.GetProductByUsername(request.Username);
            return _mapper.Map<List<ProductsVm>>(productList);
        }
    }
}
