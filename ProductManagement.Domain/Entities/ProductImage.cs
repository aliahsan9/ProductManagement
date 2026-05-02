using ProductManagement.Domain.Common;

namespace ProductManagement.Domain.Entities
{
    public class ProductImage : BaseEntity
    {
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsMain { get; set; }
        // Foreign Key to Product
        public int ProductId { get; set; }
        // Navigation property (Many to 1)
        public Product? Product { get; set; }

    }
}
