
using CleanStore.Domain.Models.Common;

namespace CleanStore.Domain.Models
{
    public class Product : BaseDomainModel
    {

        public Product()
        {
            Categories = new HashSet<Category>();
        }

        public string? Name { get; set; }
        public double Price { get; set; }
        public long Quantity { get; set; }
        public int SellerId { get; set; }
        public virtual Seller? Seller { get; set; }
        public virtual ProductDetail? ProductDetail { get; set; }
        public virtual ICollection<Category>? Categories { get; set; }
    }
}
