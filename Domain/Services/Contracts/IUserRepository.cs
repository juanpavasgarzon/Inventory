namespace Domain.Services.Contracts;

public interface IUserRepository
{
    Task<Entities.User> CreateUserAsync(Entities.User user);

    Task<Entities.User> FindUserAsync(int userId);
}