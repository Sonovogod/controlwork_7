using Library.Enums;
using Library.Models;

namespace Library.Services.ViewModels;

public class ShortBookViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ImgPath { get; set; }
    public User User { get; set; }
    public DateTime? DateAdded { get; set; }
    public BookStates? States { get; set; }
}