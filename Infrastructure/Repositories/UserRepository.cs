using Domain.Exceptions;
using Domain.Services.Contracts;
using Infrastructure.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using Entities = Domain.Entities;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly InventoryContext _context;

    public UserRepository(InventoryContext context)
    {
        _context = context;
    }

    public async Task<Entities.User> CreateUserAsync(Entities.User user)
    {
        try
        {
            var userModel = new User(user.Username, user.Password, true);

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
}