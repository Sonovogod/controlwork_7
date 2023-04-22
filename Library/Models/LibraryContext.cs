using Microsoft.EntityFrameworkCore;

namespace Library.Models;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) {}
}