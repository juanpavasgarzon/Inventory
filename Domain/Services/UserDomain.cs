using Domain.Commands;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Queries;
using Domain.Services.Contracts;
using Libraries.Abstractions.Contracts;

namespace Domain.Services;

public class UserDomain : IUserDomain, IDomain
{
    private readonly IUnitOfWork _unitOfWork;

    public UserDomain(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<User>> GetUsersAsync()
    {
        return await _unitOfWork.UserRepository.GetUsersAsync();
    }

    public async Task<User> CreateUserAsync(CreateUserCommand command)
    {
        if (command.Password != command.PasswordConfirm)
        {
            throw new PasswordNotMatchException("Passwords not match");
        }

        var user = new User
        {
            Username = command.Username,
            Password = command.Password
        };

        await _unitOfWork.SaveChangesAsync();

        return await _unitOfWork.UserRepository.CreateUserAsync(user);
    }

    public async Task<User> FindUserAsync(FindUserQuery query)
    {
        return await _unitOfWork.UserRepository.FindUserAsync(query.UserId);
    }

    public async Task<User> InactivateUserAsync(InactivateUserCommand command)
    {
        return await _unitOfWork.UserRepository.InactivateUserAsync(command.UserId);
    }
}