
using AutoMapper;
using CleanStore.Application.Features.Products.Queries.GetProducts;
using CleanStore.Application.Features.Sellers.Commands.CreateSellers;
using CleanStore.Domain.Models;

namespace CleanStore.Application.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductsVm>();
            CreateMap<CreateSellerCommand, Seller>();
        }
    }
}
