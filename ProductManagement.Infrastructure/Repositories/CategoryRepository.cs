using Microsoft.EntityFrameworkCore;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Domain.Entities;
using ProductManagement.Infrastructure.Persistence;

namespace ProductManagement.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<CategoryRepository> ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

    }
}
