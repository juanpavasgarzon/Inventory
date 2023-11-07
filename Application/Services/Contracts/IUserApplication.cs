using Domain.Commands;
using Domain.Queries;
using Entities = Domain.Entities;

namespace Application.Services.Contracts;

public interface IUserApplication
{
    Task<List<Entities.User>> GetUsersAsync();

    Task<Entities.User> CreateUserAsync(CreateUserCommand user);

    Task<Entities.User> FindUserAsync(FindUserQuery query);

    Task<Entities.User> InactivateUserAsync(InactivateUserCommand command);
}