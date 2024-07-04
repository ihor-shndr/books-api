using Microsoft.EntityFrameworkCore;
using StreamAndDeferDemo.Models;

namespace StreamAndDeferDemo.Database;

public class BooksContext : DbContext
{
    public BooksContext(DbContextOptions<BooksContext> options) : base(options)
    {
    }
    
    public DbSet<Book> Books { get; set; }
    public DbSet<Review> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
            
        modelBuilder.ApplyConfiguration(new BooksContextConfiguration());
        modelBuilder.ApplyConfiguration(new ReviewsContextConfiguration());
    }
}