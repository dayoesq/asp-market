using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DataAccess.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Category>()
    //         .HasIndex(a => a.Name).IsUnique();
    // }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}