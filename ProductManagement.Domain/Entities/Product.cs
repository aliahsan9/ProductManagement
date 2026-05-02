using ProductManagement.Domain.Common;

namespace ProductManagement.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string SKU { get; set; } = string.Empty;
        public int StockQuantity { get; set; }

        // Foreign Key to Category
        public int CategoryId { get; set; }
        //Navigation propert (Mant to 1)
        public Category? Category { get; set; }
        public bool IsActive { get; set; } = true;
        //Navigation Property (1 to Many)
        public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    }
}
