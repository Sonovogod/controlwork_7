using Library.Models;
using Library.Services.ViewModels;

namespace Library.Extensions;

public static class BookExtensions
{
    public static List<ShortBookViewModel> MapToShortBookViewModel(this IEnumerable<Book> self)
    {
        return self.Select(b=> new ShortBookViewModel
        {
            Id = b.Id,
            Title = b.Title,
            Author = b.Author,
            ImgPath = b.ImgPath,
            States = b.States
        }).ToList();
    }
    
    public static Book MapToBookModel(this BookViewModel bookViewModel)
    {
        return new Book()
        {
            Id = bookViewModel.Id,
            Title = bookViewModel.Title,
            Description = bookViewModel.Description,
            Author = bookViewModel.Author,
            YearRelease = bookViewModel.YearRelease,
            CategoryId = bookViewModel.CategoryId
        };
    }
}