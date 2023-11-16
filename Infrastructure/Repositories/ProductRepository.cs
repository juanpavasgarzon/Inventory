using Domain.Entities;
using Domain.Services.Contracts;

namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly InventoryDbContext _context;

    public ProductRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public Task<List<Product>> GetProductAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product> CreateProductAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product> FindProductAsync()
    {
        throw new NotImplementedException();
    }

    public Task InactivateProductAsync()
    {
        throw new NotImplementedException();
    }
}