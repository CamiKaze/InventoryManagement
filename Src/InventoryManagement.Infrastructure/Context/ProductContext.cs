using InventoryManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.Context;

// 1. Create the database context.
// 2. Inherit from the DbContext class.
// 3. Provide the models needed for migration.
public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options)
    : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}