using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Domain.Entities;
using ProductManagement.Infrastructure.Persistence;

namespace ProductManagement.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<ProductRepository>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base (context) { }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .ToListAsync();
        }
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(P => P.Category)
                .Include(P => P.ProductImages)
                .FirstOrDefaultAsync(P => P.Id == id);

        }
        public async Task<Product> AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }
        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
        }
        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
        }
    }
}
