using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Library.Services.ViewModels;

public class CategoryViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Поле не может быть пустым")]
    [Remote("CheckUniqueName", "CategoryValidation", ErrorMessage = "Такое наименоване бренда уже есть", AdditionalFields = "Title, Id")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Минимальное количество знаков: 3, Максимальное - 50")]

    public string Title { get; set; }
}