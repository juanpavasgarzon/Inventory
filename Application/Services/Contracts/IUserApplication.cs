using Domain.Commands;
using Domain.Queries;
using Entities = Domain.Entities;

namespace Application.Services.Contracts;

public interface IUserApplication
{
    Task<Entities.User> CreateUserAsync(CreateUserCommand user);

    Task<Entities.User> FindUserAsync(FindUserQuery query);
}