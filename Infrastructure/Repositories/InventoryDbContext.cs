using Infrastructure.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class InventoryDbContext : DbContext
{
    public InventoryDbContext()
    {
    }

    public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=Inventory;Username=postgres;Password=123456");
    }

    public required DbSet<User> Users { get; set; }

    public required DbSet<Brand> Brands { get; set; }

    public required DbSet<Category> Categories { get; set; }

    public required DbSet<ProductType> ProductTypes { get; set; }

    public required DbSet<Supplier> Suppliers { get; set; }

    public required DbSet<Product> Products { get; set; }
}