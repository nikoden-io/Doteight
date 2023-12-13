using indiereb.Models;
using Microsoft.EntityFrameworkCore;

namespace indiereb.Data;

public class ApplicationDbContext : DbContext
{
    // Import the connection string from appsettings.json
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // Create tables in the database
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Add seed data
        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                CategoryId = 1,
                Name = "Action",
                DisplayOrder = 1
            },
            new Category
            {
                CategoryId = 2,
                Name = "SciFi",
                DisplayOrder = 2
            },
            new Category
            {
                CategoryId = 3,
                Name = "Documentary",
                DisplayOrder = 3
            }
        );
    }
}