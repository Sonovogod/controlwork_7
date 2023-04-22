using Library.Models;
using Library.Services.ViewModels;

namespace Library.Extensions;

public static class CategoryExtensions
{
    public static List<CategoryViewModel> MapToCategoriesViewModels(this IEnumerable<Category> self)
    {
        return self.Select(c => new CategoryViewModel
        {
            Id = c.Id,
            Title = c.Title
        }).ToList();
    }

    public static Category MapToCategoryModel(this CategoryViewModel category)
    {
        return new Category
        {
            Id = category.Id,
            Title = category.Title
        };
    }
}