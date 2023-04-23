namespace Library.Services.ViewModels;

public class BooksPageViewModel
{
    public List<ShortBookViewModel> Books { get; set; }
    public PaginationViewModel Pagination { get; set; }
}