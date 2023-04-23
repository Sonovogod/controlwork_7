using Library.Models;
using Library.Services.ViewModels;

namespace Library.Services.Abstracts;

public interface IUserService
{
    public void Add(User user);
    public List<ShortBookViewModel> GetUserBooks(string mail);
    public User? GetByMail(string mail);
}