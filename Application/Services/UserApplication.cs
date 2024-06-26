using Application.Services.Contracts;
using Domain.Commands;
using Domain.Entities;
using Domain.Queries;
using Domain.Services.Contracts;
using Libraries.Abstractions.Contracts;

namespace Application.Services;

public class UserApplication : IUserApplication, IApplication
{
    private readonly IUserDomain _userDomain;

    public UserApplication(IUserDomain userDomain)
    {
        _userDomain = userDomain;
    }

    public async Task<List<User>> GetUsersAsync()
    {
        return await _userDomain.GetUsersAsync();
    }

    public async Task<int> CreateUserAsync(CreateUserCommand command)
    {
        return await _userDomain.CreateUserAsync(command);
    }

    public async Task<User> FindUserAsync(FindUserQuery query)
    {
        return await _userDomain.FindUserAsync(query);
    }

    public async Task InactivateUserAsync(int userId)
    {
        await _userDomain.InactivateUserAsync(userId);
    }
}