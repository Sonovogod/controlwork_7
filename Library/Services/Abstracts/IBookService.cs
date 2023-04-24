using Library.Models;
using Library.Services.ViewModels;
namespace Library.Services.Abstracts;

public interface IBookService
{
    public IOrderedQueryable<Book> GetAllQueryable();
    public void Add(Book book);
    public BookViewModel GetById(int id);
    public void DeleteBook(Book book);
    public void Update(Book book);
    public void TakeBook(Book book);
    public void GiveBook(Book book);
    public List<BookViewModel> GetAllTakenBook();
}