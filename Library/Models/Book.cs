using Library.Enums;

namespace Library.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public string ImgPath { get; set; }
    public int YearRelease { get; set; }
    public DateTime DateAdded { get; set; }
    public BookStates States { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
    
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}