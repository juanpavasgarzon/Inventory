using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Repositories.Models;

public class Product
{
    public Product(
        string code,
        string name,
        string description,
        float unitPrice,
        float quantityAvailable,
        int id,
        int productTypeId,
        int categoryId,
        int brandId,
        int supplierId,
        Dictionary<string, string> observations
    )
    {
        Code = code;
        Name = name;
        Description = description;
        UnitPrice = unitPrice;
        QuantityAvailable = quantityAvailable;
        Id = id;
        ProductTypeId = productTypeId;
        CategoryId = categoryId;
        BrandId = brandId;
        SupplierId = supplierId;
        Observations = observations;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MaxLength(100)] public string Code;

    [MaxLength(100)] public string Name;

    [MaxLength(250)] public string Description;

    public float UnitPrice;

    public float QuantityAvailable;

    public int ProductTypeId { get; set; }

    public ProductType ProductType { get; set; } = null!;

    public int CategoryId { get; set; }

    public Category Category { get; set; } = null!;

    public int BrandId { get; set; }

    public Brand Brand { get; set; } = null!;

    public int SupplierId { get; set; }

    public Supplier Supplier { get; set; } = null!;

    public Dictionary<string, string> Observations { get; set; }
}