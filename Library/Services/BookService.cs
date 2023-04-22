using Library.Enums;
using Library.Extensions;
using Library.Models;
using Library.Services.Abstracts;
using Library.Services.ViewModels;

namespace Library.Services;

public class BookService : IBookService
{
    private readonly LibraryContext _db;

    public BookService(LibraryContext db)
    {
        _db = db;
    }

    public List<ShortBookViewModel> GetAll()
    {
        return _db.Books.MapToShortBookViewModel();
    }

    public void Add(Book book)
    {
        book.DateAdded = DateTime.Now;
        book.States = BookStates.InStock;
        _db.Books.Add(book);
        _db.SaveChanges();
    }
}