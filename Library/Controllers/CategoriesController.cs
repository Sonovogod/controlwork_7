using Library.Extensions;
using Library.Models;
using Library.Services.Abstracts;
using Library.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

public class CategoriesController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public IActionResult CreateCategory()
    {
        CreateCategoryViewModel createCategoryViewModel = new CreateCategoryViewModel()
        {
            Categories = _categoryService.GetAll()
        };
        return View(createCategoryViewModel);
    }
    
    [HttpPost]
    public IActionResult CreateCategory(CreateCategoryViewModel createCategoryViewModel)
    {
        if (ModelState.IsValid)
        {
            Category category = createCategoryViewModel.Category.MapToCategoryModel();
            _categoryService.Add(category);
        }
        return View(createCategoryViewModel);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        Category? category = _categoryService.GetById(id);
        if (category is null) return NotFound();
        _categoryService.Delete(category);

        return RedirectToAction("CreateCategory");
    }
}