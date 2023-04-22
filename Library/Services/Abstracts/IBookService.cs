using Library.Services.ViewModels;
namespace Library.Services.Abstracts;

public interface IBookService
{
    public List<ShortBookViewModel> GetAll();
}