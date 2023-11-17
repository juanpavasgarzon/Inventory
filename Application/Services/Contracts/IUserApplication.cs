using Domain.Commands;
using Domain.Queries;
using Domain.Entities;

namespace Application.Services.Contracts;

public interface IUserApplication
{
    Task<List<User>> GetUsersAsync();

    Task<int> CreateUserAsync(CreateUserCommand user);

    Task<User> FindUserAsync(FindUserQuery query);

    Task InactivateUserAsync(int userId);
}