using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Library.Services.ViewModels;

public class UserViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Поле не может быть пустым")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Минимальное количество знаков: 2, Максимальное - 50")]
    [RegularExpression(@"^[а-яА-Яa-zA-Z]+$", ErrorMessage = "Неверный формат ввода")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Поле не может быть пустым")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Минимальное количество знаков: 2, Максимальное - 50")]
    [RegularExpression(@"^[а-яА-Яa-zA-Z]+$", ErrorMessage = "Неверный формат ввода")]
    public string Surname { get; set; }
    [EmailAddress (ErrorMessage = "Некорректный адрес")]
    [RegularExpression(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$", ErrorMessage = "Неверный формат ввода")]
    [Remote("CheckUniqueName", "UserValidation", ErrorMessage = "Такой адрес уже есть в системе", AdditionalFields = "Mail")]
    public string Mail { get; set; }
    [Phone (ErrorMessage = "Неверный формат телефона")]
    public string PhoneNumber { get; set; }
}