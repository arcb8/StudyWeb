using Microsoft.EntityFrameworkCore;
using StudyWeb.Entities;

namespace StudyWeb.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Book> Books { get; set; }
    public DbSet<Product> Products { get; set; }
}