using Domain.Services.Contracts;

namespace Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly InventoryDbContext _context;

    public UnitOfWork(InventoryDbContext context)
    {
        context.Database.EnsureCreated();
        _context = context;
    }

    private IUserRepository? _userRepository;

    public IUserRepository UserRepository
    {
        get { return _userRepository ??= new UserRepository(_context); }
    }

    private IBrandRepository? _brandRepository;

    public IBrandRepository BrandRepository
    {
        get { return _brandRepository ??= new BrandRepository(_context); }
    }

    private ICategoryRepository? _categoryRepository;

    public ICategoryRepository CategoryRepository
    {
        get { return _categoryRepository ??= new CategoryRepository(_context); }
    }

    private IProductTypeRepository? _productTypeRepository;

    public IProductTypeRepository ProductTypeRepository
    {
        get { return _productTypeRepository ??= new ProductTypeRepository(_context); }
    } 

    private ISupplierRepository? _supplierRepository;

    public ISupplierRepository SupplierRepository
    {
        get { return _supplierRepository ??= new SupplierRepository(_context); }
    }

    private IProductRepository? _productRepository;

    public IProductRepository ProductRepository
    {
        get { return _productRepository ??= new ProductRepository(_context); }
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}