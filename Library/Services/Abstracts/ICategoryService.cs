using Library.Models;
using Library.Services.ViewModels;

namespace Library.Services.Abstracts;

public interface ICategoryService
{
    public List<CategoryViewModel> GetAll();
    public void Add(Category category);
    public Category? GetById(int id);
    public void Delete(Category? section);
}