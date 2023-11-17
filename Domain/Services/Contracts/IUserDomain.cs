using Domain.Commands;
using Domain.Queries;

namespace Domain.Services.Contracts;

public interface IUserDomain
{
    Task<List<Entities.User>> GetUsersAsync();

    Task<int> CreateUserAsync(CreateUserCommand command);

    Task<Entities.User> FindUserAsync(FindUserQuery query);

    Task InactivateUserAsync(int userId);
}