using Domain.Exceptions;
using Domain.Services.Contracts;
using Infrastructure.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using Entities = Domain.Entities;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly InventoryDbContext _context;

    public UserRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public Task<List<Entities.User>> GetUsersAsync()
    {
        return _context.Users.Select(model => new Entities.User
            {
                Id = model.Id,
                Username = model.Username,
                State = model.State
            }
        ).ToListAsync(); 
    }

    public async Task<int> CreateUserAsync(Entities.User user)
    {
        var userModel = new User
        {
            Username = user.Username,
            Password = user.Password,
            State = true
        };

        await _context.Users.AddAsync(userModel);
        await _context.SaveChangesAsync();
        return userModel.Id;
    }

    public async Task<Entities.User> FindUserAsync(int userId)
    {
        var userModel = await _context.Users.FirstOrDefaultAsync(model => model.Id == userId)
                        ?? throw new UserNotFoundException($"User with userId:'{userId}' not found");

        return new Entities.User
        {
            Id = userModel.Id,
            Username = userModel.Username,
            State = userModel.State,
        };
    }

    public async Task InactivateUserAsync(int userId)
    {
        var userModel = await _context.Users.FirstOrDefaultAsync(model => model.Id == userId)
                        ?? throw new UserNotFoundException($"User with userId:'{userId}' not found");

        userModel.State = false;
        _context.Users.Update(userModel);
        await _context.SaveChangesAsync();
    }
}