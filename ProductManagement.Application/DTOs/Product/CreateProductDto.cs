using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Application.DTOs.Product
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Range(0.1, double.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        public string SKU { get; set; } = string.Empty;
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }
        public int CategroyId { get; set; }

    }
}
