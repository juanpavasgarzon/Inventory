using Domain.Commands;
using Domain.Queries;

namespace Domain.Services.Contracts;

public interface IUserDomain
{
    Task<List<Entities.User>> GetUsersAsync();

    Task<Entities.User> CreateUserAsync(CreateUserCommand command);

    Task<Entities.User> FindUserAsync(FindUserQuery query);

    Task<Entities.User> InactivateUserAsync(InactivateUserCommand command);
}