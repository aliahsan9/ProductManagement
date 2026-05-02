using ProductManagement.Domain.Common;

namespace ProductManagement.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        // Navigation property for related products(1 --> Many)
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
