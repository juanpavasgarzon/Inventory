using Infrastructure.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class InventoryContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public InventoryContext()
    {
    }

    public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=Inventory;Username=postgres;Password=123456");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}