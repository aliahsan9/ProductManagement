using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Application.Interfaces.UnitOfWork;
using ProductManagement.Infrastructure.Persistence;

namespace ProductManagement.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IProductRepository Products { get; }
        public ICategoryRepository Category { get; }
        public AppDbContext(AppDbContext context ,IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _context = context;
            Products = productRepository;
            Categories = categoryRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
