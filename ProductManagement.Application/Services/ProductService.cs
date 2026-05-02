using AutoMapper;
using ProductManagement.Application.DTOs.Product;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Application.Interfaces.Services;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Services
{
    public class ProductService(IProductRepository repository, Mapper mapper) : IProductService
    {
        private readonly IProductRepository _repository = repository;
        private readonly Mapper _mapper = mapper;

        public async Task<List<ProductResponseDto>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();
            return _mapper.Map<List<ProductResponseDto>>(products);
        }
        public async Task<ProductResponseDto?> GetByIdAsync(Guid id)
        {
            var products = await _repository.GetByIdAsync(id);
            if (products == null) return null;

            return _mapper.Map<ProductResponseDto>(products);
        }
        public async Task<int> CreateAsync(CreateProductDto dto)
        {
            var product _mapper.Map<Product>(dto);

            await _repository.CreateAsync(product);
            return product.Id;

        }
    }
}
