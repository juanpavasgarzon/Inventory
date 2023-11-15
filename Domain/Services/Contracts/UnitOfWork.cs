namespace Domain.Services.Contracts;

public interface IUnitOfWork
{
    public IUserRepository UserRepository { get; }

    public IBrandRepository BrandRepository { get; }

    public ICategoryRepository CategoryRepository { get; }

    public IProductTypeRepository ProductTypeRepository { get; }

    public ISupplierRepository SupplierRepository { get; }

    public IProductRepository ProductRepository { get; }

    Task SaveChangesAsync();
}