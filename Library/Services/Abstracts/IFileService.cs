using Library.Models;

namespace Library.Services.Abstracts;

public interface IFileService
{
    public string SaveFileAndGetPath(Book book, IFormFile uploadedFile);
    public bool ValidFile(IFormFile uploadedFile);
}