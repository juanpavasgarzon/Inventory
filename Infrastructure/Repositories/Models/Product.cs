using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Repositories.Models;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MaxLength(100)] public string Code;

    [MaxLength(100)] public string Name;

    [MaxLength(250)] public string Description;

    public float UnitPrice;

    public float QuantityAvailable;

    public int ProductTypeId { get; set; }

    public ProductType ProductType { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }

    public int BrandId { get; set; }

    public Brand Brand { get; set; }

    public int SupplierId { get; set; }

    public Supplier Supplier { get; set; }

    public Dictionary<string, string> Observations { get; set; }

    [Timestamp] public uint Version { get; set; }
}