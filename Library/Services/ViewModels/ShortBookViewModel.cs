using Library.Enums;

namespace Library.Services.ViewModels;

public class ShortBookViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ImgPath { get; set; }
    public BookStates? States { get; set; }
}