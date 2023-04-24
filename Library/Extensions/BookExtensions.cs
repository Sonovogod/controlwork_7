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
    
    public static ShortBookViewModel MapToShortBookViewModel(this Book self)
    {
        return new ShortBookViewModel
        {
            Id = self.Id,
            Title = self.Title,
            Author = self.Author,
            ImgPath = self.ImgPath,
            States = self.States,
            DateAdded = self.DateAdded,
            User = self.User
        };
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