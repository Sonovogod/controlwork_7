using Library.Enums;
using Microsoft.EntityFrameworkCore;

namespace Library.Models;

public class LibraryContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasQueryFilter(book => book.States != BookStates.Deleted);
        base.OnModelCreating(modelBuilder);
    }
}