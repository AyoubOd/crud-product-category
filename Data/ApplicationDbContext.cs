using Microsoft.EntityFrameworkCore;
using tp11.Models;

namespace tp11.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; init; }
    public virtual DbSet<Category> Categories { get; init; }
}