using ProductManagement.Application.Interfaces.Repositories;

namespace ProductManagement.Application.Interfaces.UnitOfWork;

public interface IUnitOfWork
{
    IProductRepository Products { get; }
    ICategoryRepository Categories { get; }

    Task<int> SaveChangesAsync();
}