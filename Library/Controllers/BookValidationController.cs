using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

public class BookValidationController : Controller
{
    private readonly LibraryContext _db;

    public BookValidationController(LibraryContext db)
    {
        _db = db;
    }

    [AcceptVerbs("Get", "Post")]
    public bool CheckUniqueTitle([Bind(Prefix = "Book.Title")] string title, [Bind(Prefix = "Book.Id")] int id)
    {
        if (id != 0)
        {
            bool nameIsExist = _db.Books.Any(x => x.Id != id && x.Title == title);
            if (nameIsExist)
                return false;
            return true;
        }
        return !_db.Books.Any(x => x.Title.Equals(title));
    }
    
    [AcceptVerbs("Get", "Post")]
    public bool CheckYear([Bind(Prefix = "Book.YearRelease")] int yearRelease)
    {
        DateTime totalYear = DateTime.Now;
        if (yearRelease <= totalYear.Year && yearRelease >= 1000)
            return true;
        return false;
    }
    
    [AcceptVerbs("Get", "Post")]
    public bool CheckCategory([Bind(Prefix = "Book.CategoryId")] int categoryId)
    {
        return _db.Categories.Any(x=> x.Id == categoryId);
    }
}