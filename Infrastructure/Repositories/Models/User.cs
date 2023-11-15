using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Repositories.Models;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MaxLength(100)] public string Username { get; set; }

    [MaxLength(100)] public string Password { get; set; }

    [MaxLength(100)] public bool State { get; set; }

    [Timestamp] public uint Version { get; set; }

    public bool IsDeleted { get; set; }
}