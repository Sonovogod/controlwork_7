using Library.Models;
using Library.Services.ViewModels;

namespace Library.Extensions;

public static class BookExtensions
{
    public static List<ShortBookViewModel> MapToShortBooksViewModel(this IEnumerable<Book> self)
    {
        return self.Select(b=> new ShortBookViewModel
        {
            Id = b.Id,
            Title = b.Title,
            Author = b.Author,
            ImgPath = b.ImgPath,
            States = b.States,
            DateAdded = b.DateAdded
        }).ToList();
    }
    public static List<BookViewModel> MapToBookViewModel(this IEnumerable<Book> self)
    {
        return self.Select(b=> new BookViewModel
        {
            Id = b.Id,
            Title = b.Title,
            Description = b.Description,
            Author = b.Author,
            YearRelease = b.YearRelease,
            CategoryId = b.CategoryId,
            ImgPath = b.ImgPath,
            DateAdded = b.DateAdded,
            States = b.States,
            UserId = b.UserId,
            User = b.User
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
            CategoryId = bookViewModel.CategoryId,
            ImgPath = bookViewModel.ImgPath,
            DateAdded = bookViewModel.DateAdded,
            States = bookViewModel.States,
            UserId = bookViewModel.UserId
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
            UserId = book.UserId,
            Author = book.Author,
            ImgPath = book.ImgPath,
            States = book.States,
            Category = book.Category
        };
    }
}