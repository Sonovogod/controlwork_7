using Library.Models;
using Library.Services.ViewModels;

namespace Library.Extensions;

public static class UserExtension
{
    public static User MapToUserModel(this UserViewModel userViewModel)
    {
        return new User()
        {
            Id = userViewModel.Id,
            Name = userViewModel.Name,
            Mail = userViewModel.Mail,
            PhoneNumber = userViewModel.PhoneNumber,
            Surname = userViewModel.Surname
        };
    }
}