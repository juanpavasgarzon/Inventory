using Domain.Entities;
using Domain.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly InventoryDbContext _context;

    public ProductRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetProductAsync()
    {
        return await _context.Products
            .Select(model => new Product
                {
                    Id = model.Id
                }
            )
            .ToListAsync();
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