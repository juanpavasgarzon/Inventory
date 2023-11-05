using Domain.Services.Contracts;

namespace Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly InventoryContext _context;
    private readonly IServiceProvider _serviceProvider;

    public UnitOfWork(InventoryContext context, IServiceProvider serviceProvider)
    {
        _context = context;
        _serviceProvider = serviceProvider;
    }

    private IUserRepository? _userRepository;

    public IUserRepository UserRepository
    {
        get
        {
            _userRepository ??= new UserRepository(_context);
            return _userRepository;
        }
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}