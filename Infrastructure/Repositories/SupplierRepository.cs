using Entities = Domain.Entities;
using Domain.Services.Contracts;
using Infrastructure.Repositories.Models;

namespace Infrastructure.Repositories;

public class SupplierRepository : ISupplierRepository
{
    private readonly InventoryDbContext _context;

    public SupplierRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateUserAsync(Entities.Supplier supplier)
    {
        var supplierModel = new Supplier
        {
            Name = supplier.Name,
            Address = supplier.Address,
            Phone = supplier.Phone
        };

        await _context.Suppliers.AddAsync(supplierModel);
        await _context.SaveChangesAsync();
        return supplierModel.Id;
    }
}