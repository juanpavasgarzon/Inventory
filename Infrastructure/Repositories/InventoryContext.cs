using System.Diagnostics;
using Ilse.Infrastructure.BaseContext.Context;
using Infrastructure.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class InventoryContext : BaseContext
{
    public DbSet<User> Users { get; set; }

    public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=Inventory;Username=postgres;Password=123456");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}