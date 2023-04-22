using Library.Models;
using Library.Services.ViewModels;
namespace Library.Services.Abstracts;

public interface IBookService
{
    public List<ShortBookViewModel> GetAll();
    public void Add(Book book);
    public BookViewModel GetById(int id);
    public void DeleteBook(Book book);
}