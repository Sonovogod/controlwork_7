using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Library.Services.ViewModels;

public class AuthorizationUserViewModel
{
    [EmailAddress (ErrorMessage = "Некорректный адрес")]
    [RegularExpression(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$", ErrorMessage = "Неверный формат ввода")]
    [Remote("CheckLoginMail", "UserValidation", ErrorMessage = "Такого пользователя нет в системе", AdditionalFields = "Mail")]
    public string Mail { get; set; }
}