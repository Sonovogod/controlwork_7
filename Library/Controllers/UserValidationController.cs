using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

public class UserValidationController : Controller
{
    private readonly LibraryContext _db;

    public UserValidationController(LibraryContext db)
    {
        _db = db;
    }

    [AcceptVerbs("Get", "Post")]
    public bool CheckUniqueName([Bind(Prefix = "User.Mail")]string mail)
    {
        bool nameIsExist = _db.Users.Any(x => x.Mail.ToUpper().Equals(mail.ToUpper()));
            if (nameIsExist)
                return false;
            return true;
    }
    
    [AcceptVerbs("Get", "Post")]
    public bool CheckLoginMail([Bind(Prefix = "AuthorUser.Mail")]string mail)
    {
        bool nameIsExist = _db.Users.Any(x => x.Mail.ToUpper().Equals(mail.ToUpper()));
        if (nameIsExist)
            return true;
        return false;
    }
}