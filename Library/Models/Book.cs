namespace Library.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public string ImgPath { get; set; }
    public DateTime DateRelease { get; set; }
    public DateTime DateAdded { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
}