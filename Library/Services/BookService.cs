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
}