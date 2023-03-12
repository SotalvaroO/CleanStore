
namespace CleanStore.Application.Features.Products.Queries.GetProducts
{
    public class ProductsVm
    {
        public string? Name { get; set; }
        public double Price { get; set; }
        public long Quantity { get; set; }
        public int SellerId { get; set; }
    }
}
