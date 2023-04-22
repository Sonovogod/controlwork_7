using Library.Models;
using Library.Services.Abstracts;

namespace Library.Services;

public class FileService : IFileService
{
    private readonly IHostEnvironment _hostEnvironment;

    public FileService(IHostEnvironment hostEnvironment)
    {
        _hostEnvironment = hostEnvironment;
    }

    public string SaveFileAndGetPath(Book book, IFormFile uploadedFile)
    {
        if (uploadedFile != null)
        {
            string dir = Path.Combine(_hostEnvironment.ContentRootPath,"wwwroot/Files/Img/");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            string fileName = uploadedFile.FileName;
            string path = $"{dir}{fileName}";
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                uploadedFile.CopyTo(fileStream);
            }
            return $"/Files/Img/{fileName}";
        }

        return string.Empty;
    }
}