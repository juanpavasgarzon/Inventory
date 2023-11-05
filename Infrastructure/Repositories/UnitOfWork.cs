using Domain.Services.Contracts;

namespace Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly InventoryContext _context;

    public UnitOfWork(InventoryContext context)
    {
        _context = context;
    }

    private IUserRepository? _userRepository;

    public IUserRepository UserRepository
    {
        get { return _userRepository ??= new UserRepository(_context); }
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}