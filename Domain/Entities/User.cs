using System.Text.Json.Serialization;

namespace Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    [JsonIgnore] public string Password { get; set; }
    public bool State { get; set; }
}