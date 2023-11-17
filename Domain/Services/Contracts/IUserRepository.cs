using Domain.Entities;

namespace Domain.Services.Contracts;

public interface IUserRepository
{
    Task<List<User>> GetUsersAsync();

    Task<int> CreateUserAsync(User user);

    Task<User> FindUserAsync(int userId);

    Task InactivateUserAsync(int userId);
}