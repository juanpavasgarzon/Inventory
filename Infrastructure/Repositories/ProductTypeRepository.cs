using Domain.Services.Contracts;

namespace Infrastructure.Repositories;

public class ProductTypeRepository : IProductTypeRepository
{
    private readonly InventoryDbContext _context;

    public ProductTypeRepository(InventoryDbContext context)
    {
        _context = context;
    }
}