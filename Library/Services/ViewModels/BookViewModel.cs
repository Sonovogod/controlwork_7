using System.ComponentModel.DataAnnotations;
using Library.Enums;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Services.ViewModels;

public class BookViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Поле не может быть пустым")]
    [Remote("CheckUniqueTitle", "BookValidation", ErrorMessage = "Такое наименоване книги уже есть", AdditionalFields = "Title, Id")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Минимальное количество знаков: 1, Максимальное - 50")]
    public string Title { get; set; }
    [Required(ErrorMessage = "Поле не может быть пустым")]
    [StringLength(505, MinimumLength = 10, ErrorMessage = "Минимальное количество знаков: 10, Максимальное - 500")]
    public string Description { get; set; }
    [Required(ErrorMessage = "Поле не может быть пустым")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Минимальное количество знаков: 3, Максимальное - 50")]
    public string Author { get; set; }
    public string? ImgPath { get; set; }
    [Required(ErrorMessage = "Поле не может быть пустым")]
    [Remote("CheckYear", "BookValidation", ErrorMessage = "Дата написания не должна быть старее 1000 года и не больше текущего года", AdditionalFields = "YearRelease")]
    public int YearRelease { get; set; }
    [Required(ErrorMessage = "Поле не может быть пустым")]
    public int CategoryId { get; set; }
    public DateTime? DateAdded { get; set; }
    public BookStates? States { get; set; }
    public User? User { get; set; }
    public Category? Category { get; set; }
    public int? UserId { get; set; }
}