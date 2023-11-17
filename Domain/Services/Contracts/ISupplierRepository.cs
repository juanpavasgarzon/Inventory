namespace Domain.Services.Contracts;

public interface ISupplierRepository
{
    Task<int> CreateUserAsync(Entities.Supplier supplier);
}