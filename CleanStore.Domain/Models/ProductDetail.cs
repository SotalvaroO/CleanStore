
using CleanStore.Domain.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace CleanStore.Domain.Models
{
    public class ProductDetail : BaseDomainModel
    {
        public string? Description { get; set; }
        public string? Sku { get; set; }
        public int ProductId { get; set; }
        [Required]
        public virtual Product? Product { get; set; }
    }
}
