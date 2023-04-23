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

    public BooksController(
        IBookService bookService, 
        ICategoryService categoryService, 
        IFileService fileService)
    {
        _bookService = bookService;
        _categoryService = categoryService;
        _fileService = fileService;
    }

    [HttpGet]
    public IActionResult Home(int currentPage = 1)
    {
        var books = _bookService.GetAllQueryable();
        int pageSize = 8;
        int count = books.Count();
        var paginationBooks = books.Skip((currentPage - 1) * pageSize).Take(pageSize).MapToShortBookViewModel();
        
        
        /*List<ShortBookViewModel> books = _bookService.GetAll();
        int pageSize = 2;
        int count = books.Count;
        var filteredBook = books.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();*/

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

        return View(bookViewModel);
    }

    [HttpGet]
    public IActionResult TakeBook(int id)
    {
        return NotFound();
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