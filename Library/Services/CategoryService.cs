using Library.Extensions;
using Library.Models;
using Library.Services.Abstracts;
using Library.Services.ViewModels;

namespace Library.Services;

public class CategoryService : ICategoryService
{
    private readonly LibraryContext _db;

    public CategoryService(LibraryContext db)
    {
        _db = db;
    }

    public List<CategoryViewModel> GetAll()
    {
        return _db.Categories.ToList().MapToCategoriesViewModels();
    }

    public void Add(Category category)
    {
        _db.Categories.Add(category);
        _db.SaveChanges();
    }
    
    public Category? GetById(int id)
        => _db.Categories.FirstOrDefault(x=> x.Id == id);
    
    public void Delete(Category? section)
    {
        _db.Categories.Remove(section);
        _db.SaveChanges();
    }
}