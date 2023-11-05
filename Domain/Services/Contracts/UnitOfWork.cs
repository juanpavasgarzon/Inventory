namespace Domain.Services.Contracts;

public interface IUnitOfWork
{
    public IUserRepository UserRepository { get; }

    Task SaveChangesAsync();
}