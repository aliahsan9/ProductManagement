using System.Text.Json;
using ProductManagement.Application.Interfaces.Caching;
using ProductManagement.Application.Interfaces.UnitOfWork;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICacheService _cache;
    private readonly IMapper _mapper;

    public ProductService(
        IUnitOfWork unitOfWork,
        ICacheService cache,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _cache = cache;
        _mapper = mapper;
    }

    public async Task<List<ProductResponseDto>> GetAllAsync()
    {
        string cacheKey = "products_all";

        var cachedData = await _cache.GetAsync(cacheKey);

        if (!string.IsNullOrEmpty(cachedData))
        {
            return JsonSerializer.Deserialize<List<ProductResponseDto>>(cachedData)!;
        }

        var products = await _unitOfWork.Products.GetAllAsync();

        var result = _mapper.Map<List<ProductResponseDto>>(products);

        await _cache.SetAsync(
            cacheKey,
            JsonSerializer.Serialize(result),
            TimeSpan.FromMinutes(10));

        return result;
    }

    public async Task<int> CreateAsync(CreateProductDto dto)
    {
        var product = _mapper.Map<Domain.Entities.Product>(dto);

        await _unitOfWork.Products.AddAsync(product);
        await _unitOfWork.SaveChangesAsync();

        // 🔥 Invalidate cache after write
        await _cache.RemoveAsync("products_all");

        return product.Id;
    }
}