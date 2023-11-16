using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Repositories.Models;

public class Supplier
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MaxLength(100)] public string Name { get; set; }

    [MaxLength(100)] public string Address { get; set; }

    [MaxLength(100)] public string Phone { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}