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
    
    public static BookViewModel MapTotBookViewModel(this Book book)
    {
        return new BookViewModel
        {
            Id = book.Id,
            Title = book.Title,
            Description = book.Description,
            YearRelease = book.YearRelease,
            CategoryId = book.CategoryId,
            DateAdded = book.DateAdded,
            User = book.User,
            Author = book.Author,
            ImgPath = book.ImgPath,
            States = book.States,
            Category = book.Category
        };
    }
}