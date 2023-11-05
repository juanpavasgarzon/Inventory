using Domain.Commands;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Queries;
using Domain.Services.Contracts;

namespace Domain.Services;

public class UserDomain : IUserDomain
{
    private readonly IUnitOfWork _unitOfWork;

    public UserDomain(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<User> CreateUserAsync(CreateUserCommand command)
    {
        if (command.Password != command.PasswordConfirm)
        {
            throw new PasswordNotMatchException("Passwords not match");
        }

        var user = new User(command.Username, command.Password);

        return await _unitOfWork.UserRepository.CreateUserAsync(user);
    }

    public async Task<User> FindUserAsync(FindUserQuery query)
    {
        return await _unitOfWork.UserRepository.FindUserAsync(query.UserId);
    }
}