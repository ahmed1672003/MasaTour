using MasaTour.TouristTripsManagement.Services.Dtos.Files;

namespace MasaTour.TouristTripsManagement.Services.Services.Contracts;
public interface IFileService
{
    private static string[] allowedExtension = new string[]
    {
        ".png",".jpg",".jpeg",".gif",".bmp",".tiff",".tif",".svg",".webp",".heic"
    };

    public bool EnsureFilesSize(IEnumerable<IFormFile> files)
    {
        foreach (var file in files)
            if (file is null || file.Length < 0 || file.Length >= (1024 * 1024) * 5)
                throw new InvalidImageSizeException("Invalid Image Size !");
        return true;
    }
    public bool EnsureFileSize(IFormFile file) =>
        (file.Length < 0 || file.Length >= (1024 * 1024) * 5) ?
            throw new InvalidImageSizeException("Invalid Image Size !") : true;
    public bool EnsureFilesExctensions(IEnumerable<IFormFile> files)
    {
        foreach (var file in files)
            if (allowedExtension.Contains(Path.GetExtension(file.FileName).ToLower()))
                throw new InvalidImageSizeException("Invalid Image Extension !");
        return true;
    }

    public bool EnsureFileExctension(IFormFile file) =>
        !allowedExtension.Contains(Path.GetExtension(file.FileName).ToLower()) ?
            throw new InvalidImageSizeException("Invalid Image Extension !") : true;

    Task<UploadFileResultDto> UploadFileAsync(IFormFile file, string storage);
    Task<bool> DeleteFileAsync(string storage, string fileName);
    Task<bool> IsFileExistAsync(string storage, string fileName);
}
