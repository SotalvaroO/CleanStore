
using CleanStore.Domain.Models.Common;

namespace CleanStore.Domain.Models
{
    public class Seller : BaseDomainModel
    {

        public Seller()
        {
            Products = new HashSet<Product>();
        }

        public string? Name { get; set; }
        public string? Url { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}
