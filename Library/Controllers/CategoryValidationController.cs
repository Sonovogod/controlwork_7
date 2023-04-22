using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

public class CategoryValidationController : Controller
{
    private readonly LibraryContext _db;

    public CategoryValidationController(LibraryContext db)
    {
        _db = db;
    }
    
    [AcceptVerbs("Get", "Post")]
    public bool CheckUniqueName([Bind(Prefix = "Category.Title")]string title, [Bind(Prefix = "Category.Id")]int id)
    {
        if (id != 0)
        {
            bool nameIsExist = _db.Categories.Any(x => x.Id != id && x.Title == title);
            if (nameIsExist)
                return false;
            return true;
        }
        return !_db.Categories.Any(x => x.Title.Equals(title));
    }
}