namespace Domain.Services.Contracts;

public interface IUserRepository
{
    Task<List<Entities.User>> GetUsersAsync();

    Task<Entities.User> CreateUserAsync(Entities.User user);

    Task<Entities.User> FindUserAsync(int userId);

    Task<Entities.User> InactivateUserAsync(int userId);
}