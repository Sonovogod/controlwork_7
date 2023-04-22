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

    public BooksController(IBookService bookService, ICategoryService categoryService, IFileService fileService)
    {
        _bookService = bookService;
        _categoryService = categoryService;
        _fileService = fileService;
    }

    [HttpGet]
    public IActionResult Home()
    {
        var books = _bookService.GetAll();
        return View(books);
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
        if (ModelState.IsValid)
        {
            Book book = createBookViewModel.Book.MapToBookModel();
            book.ImgPath = _fileService.SaveFileAndGetPath(book, uploadedFile);
            _bookService.Add(book);
            return RedirectToAction("Home");
        }
        /*ModelState.AddModelError("Img", "Не верное расширение файла");*/
        return RedirectToAction("CreateBook");
    }
    
    [HttpGet]
    public IActionResult About(int id)
    {
        return NotFound();
    }

    [HttpGet]
    public IActionResult TakeBook(int id)
    {
        return NotFound();
    }
    
}