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

    public async Task<List<Entities.User>> GetUsersAsync()
    {
        return await _context.Users.Select(model => new Entities.User
            {
                Id = model.Id,
                Username = model.Username,
                State = model.State
            }
        ).ToListAsync();
    }

    public async Task<Entities.User> CreateUserAsync(Entities.User user)
    {
        try
        {
            var userModel = new User
            {
                Username = user.Username,
                Password = user.Password,
                State = true
            };

            _context.Users.Add(userModel);
            await _context.SaveChangesAsync();

            user.Id = userModel.Id;
            user.State = userModel.State;

            return user;
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new CreateUserException("The user has not been created", ex);
        }
    }

    public Task<Entities.User> FindUserAsync(int userId)
    {
        var userModel = _context.Users.FirstOrDefault(model => model.Id == userId)
                        ?? throw new UserNotFoundException($"User with userId:'{userId}' not found");

        return Task.FromResult(new Entities.User
        {
            Id = userModel.Id,
            Username = userModel.Username,
            State = userModel.State,
        });
    }

    public async Task<Entities.User> InactivateUserAsync(int userId)
    {
        var userModel = _context.Users.FirstOrDefault(model => model.Id == userId)
                        ?? throw new UserNotFoundException($"User with userId:'{userId}' not found");

        userModel.State = false;

        _context.Users.Update(userModel);
        await _context.SaveChangesAsync();

        return new Entities.User
        {
            Id = userModel.Id,
            Username = userModel.Username,
            State = userModel.State,
        };
    }
}