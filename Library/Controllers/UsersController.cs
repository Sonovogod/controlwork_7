using Library.Extensions;
using Library.Models;
using Library.Services.Abstracts;
using Library.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

public class UsersController : Controller
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Authorization()
    {
        CreateUserViewModel createUserViewModel = new CreateUserViewModel()
        {
            User = new UserViewModel()
        };
        return View(createUserViewModel);
    }
    
    [HttpPost]
    public IActionResult Authorization(CreateUserViewModel createUserViewModel)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Cabinet", new { mail = createUserViewModel.AuthorUser.Mail });
        }
        return RedirectToAction("Authorization");
    }
    
    [HttpGet]
    public IActionResult Cabinet(string mail)
    {
        UserCabinetViewModel userCabinetViewModel = new UserCabinetViewModel()
        {
            Books = _userService.GetByMail(mail)
        };
        return View(userCabinetViewModel);
    }

    [HttpPost]
    public IActionResult Registration(CreateUserViewModel createUserViewModel)
    {
        if (ModelState.IsValid)
        {
            User user = createUserViewModel.User.MapToUserModel();
            _userService.Add(user);
            return View(createUserViewModel);
        }
        return RedirectToAction("Authorization");
    }
}