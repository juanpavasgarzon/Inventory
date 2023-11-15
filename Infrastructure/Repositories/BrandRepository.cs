using Domain.Services.Contracts;

namespace Infrastructure.Repositories;

public class BrandRepository : IBrandRepository
{
    private readonly InventoryDbContext _context;

    public BrandRepository(InventoryDbContext context)
    {
        _context = context;
    }
}