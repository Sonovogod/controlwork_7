using Library.Extensions;
using Library.Models;
using Library.Services.Abstracts;
using Library.Services.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Library.Services;

public class UserService : IUserService
{
    private readonly LibraryContext _db;

    public UserService(LibraryContext db)
    {
        _db = db;
    }

    public void Add(User user)
    {
        _db.Users.Add(user);
        _db.SaveChanges();
    }

    public List<ShortBookViewModel> GetByMail(string mail)
    {
        List<ShortBookViewModel> books = _db.Books
            .Include(x => x.User)
            .Where(x => x.User.Mail.ToUpper().Equals(mail.ToUpper())).MapToShortBookViewModel();
        return books;
    }
}