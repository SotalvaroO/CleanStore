
using CleanStore.Domain.Models.Common;

namespace CleanStore.Domain.Models
{
    public class Category : BaseDomainModel
    {

        public Category()
        {
            Products = new HashSet<Product>();
        }

        public string? Name { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}
