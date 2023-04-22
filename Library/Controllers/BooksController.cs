using Library.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

public class BooksController : Controller
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public IActionResult Home()
    {
        var books = _bookService.GetAll();
        return View(books);
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