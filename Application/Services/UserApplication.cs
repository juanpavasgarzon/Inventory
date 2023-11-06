using Application.Services.Contracts;
using Domain.Commands;
using Domain.Entities;
using Domain.Queries;
using Domain.Services.Contracts;

namespace Application.Services;

public class UserApplication : IUserApplication
{
    private readonly IUserDomain _userDomain;

    public UserApplication(IUserDomain userDomain)
    {
        _userDomain = userDomain;
    }

    public async Task<User> CreateUserAsync(CreateUserCommand command)
    {
        return await _userDomain.CreateUserAsync(command);
    }

    public async Task<User> FindUserAsync(FindUserQuery query)
    {
        return await _userDomain.FindUserAsync(query);
    }

    public async Task<User> InactivateUserAsync(InactivateUserCommand command)
    {
        return await _userDomain.InactivateUserAsync(command);
    }
}