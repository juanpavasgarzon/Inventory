namespace Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public bool State { get; set; }

    public User()
    {
    }

    public User(
        string username,
        string password
    )
    {
        Username = username;
        Password = password;
    }
}