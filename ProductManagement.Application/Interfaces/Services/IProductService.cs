using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<List<ProductResponseDto>> GetAllAsync();
        Task<ProductResponseDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(ProductResponseDto dto);
    }
}
