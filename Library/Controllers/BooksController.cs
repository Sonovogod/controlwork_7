using Library.Extensions;
using Library.Models;
using Library.Services.Abstracts;
using Library.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

public class BooksController : Controller
{
    private readonly IBookService _bookService;
    private readonly ICategoryService _categoryService;
    private readonly IFileService _fileService;
    private readonly IUserService _userService;

    public BooksController(
        IBookService bookService, 
        ICategoryService categoryService, 
        IFileService fileService, IUserService userService)
    {
        _bookService = bookService;
        _categoryService = categoryService;
        _fileService = fileService;
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Home(int currentPage = 1)
    {
        var books = _bookService.GetAllQueryable();
        int pageSize = 8;
        int count = books.Count();
        var paginationBooks = books.Skip((currentPage - 1) * pageSize).Take(pageSize).MapToShortBooksViewModel();

        BooksPageViewModel booksPageViewModel = new BooksPageViewModel()
        {
            Books = paginationBooks,
            Pagination = new PaginationViewModel(count, currentPage, pageSize)
        };

        return View(booksPageViewModel);
    }

    [HttpGet]
    public IActionResult CreateBook()
    {
        CreateBookViewModel createBookViewModel = new CreateBookViewModel
        {
            Categories = _categoryService.GetAll()
        };
        return View(createBookViewModel);
    }
    
    [HttpPost]
    public IActionResult CreateBook(CreateBookViewModel createBookViewModel, IFormFile uploadedFile)
    {
        bool fileValid = _fileService.ValidFile(uploadedFile);
        if (ModelState.IsValid && fileValid)
        {
            Book book = createBookViewModel.Book.MapToBookModel();
            book.ImgPath = _fileService.SaveFileAndGetPath(book, uploadedFile);
            _bookService.Add(book);
            return RedirectToAction("Home");
        }
        return RedirectToAction("CreateBook");
    }
    
    [HttpGet]
    public IActionResult About(int id)
    {
        BookViewModel? bookViewModel = _bookService.GetById(id);
        if (bookViewModel is null) return NotFound();
        
        AboutPageViewModel aboutPageViewModel = new AboutPageViewModel()
        {
            Book = bookViewModel
        };
        return View(aboutPageViewModel);
    }

    [HttpPost]
    public IActionResult TakeBook(AboutPageViewModel aboutPageViewModel)
    {
        if (ModelState.IsValid)
        {
            var userMail = aboutPageViewModel.AuthorUser.Mail;
            var userBooks = _userService.GetUserBooks(userMail);
            if (userBooks.Count > 2)
                return View();
            

            BookViewModel book = _bookService.GetById(aboutPageViewModel.Book.Id);
            if (book.UserId != null)
                return NotFound();
            var user = _userService.GetByMail(userMail);
            book.UserId = user.Id;
            _bookService.TakeBook(book.MapToBookModel());
            return RedirectToAction("Cabinet", "Users", new {mail = userMail});
        }
        return NotFound();
    }

    [HttpPost]
    public IActionResult TakeBookFromHome(BooksPageViewModel booksPageViewModel)
    {
        if (ModelState.IsValid)
        {
            var userMail = booksPageViewModel.AuthorUser.Mail;
            var userBooks = _userService.GetUserBooks(userMail);
            if (userBooks.Count > 2)
                return View("TakeBook");
            
            BookViewModel book = _bookService.GetById(booksPageViewModel.BookId);
            if (book.UserId != null)
                return NotFound();
            var user = _userService.GetByMail(userMail);
            book.UserId = user.Id;
            _bookService.TakeBook(book.MapToBookModel());
            return RedirectToAction("Cabinet", "Users", new {mail = userMail});
        }

        return NotFound();
    }
    
    [HttpGet]
    public IActionResult GiveBook(int id)
    {
        Book book = _bookService.GetById(id).MapToBookModel();
        if (book is null) return NotFound();
        _bookService.GiveBook(book);
        return View();
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        BookViewModel? bookViewModel = _bookService.GetById(id);
        if (bookViewModel is null) return NotFound();
        Book? book = bookViewModel.MapToBookModel();
        _bookService.DeleteBook(book);
        
        return RedirectToAction("Home");
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        BookViewModel? bookViewModel = _bookService.GetById(id);
        if (bookViewModel is null) return NotFound();
        CreateBookViewModel createBookViewModel = new CreateBookViewModel()
        {
            Book = bookViewModel,
            Categories = _categoryService.GetAll()
        };
        
        return View(createBookViewModel);
    }
    
    [HttpPost]
    public IActionResult Edit(CreateBookViewModel createBookViewModel, IFormFile uploadedFile)
    {
        bool fileValid = _fileService.ValidFile(uploadedFile);
        if (ModelState.IsValid && fileValid)
        {
            Book book = createBookViewModel.Book.MapToBookModel();
            book.ImgPath = _fileService.SaveFileAndGetPath(book, uploadedFile);
            _bookService.Update(book);
            return RedirectToAction("Home");
        }
        return RedirectToAction("CreateBook");
    }
}