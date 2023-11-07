using Infrastructure.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class InventoryDbContext : DbContext
{
    public required DbSet<User> Users { get; set; }

    public InventoryDbContext()
    {
    }

    public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
    {
    }
}