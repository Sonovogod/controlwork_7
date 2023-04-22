using Library.Models;

namespace Library.Services.ViewModels;

public class CreateBookViewModel
{
    public BookViewModel Book { get; set; }
    public List<CategoryViewModel>? Categories { get; set; }
}