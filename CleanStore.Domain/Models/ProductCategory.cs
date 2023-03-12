
using CleanStore.Domain.Models.Common;

namespace CleanStore.Domain.Models
{
    public class ProductCategory : BaseDomainModel
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
    }
}
