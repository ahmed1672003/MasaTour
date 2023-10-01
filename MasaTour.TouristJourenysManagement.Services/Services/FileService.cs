using MasaTour.TouristTripsManagement.Services.Dtos.Files;

namespace MasaTour.TouristTripsManagement.Services.Services;
public sealed class FileService : IFileService
{
    private static string[] allowedExtension = new string[]
    {
            ".png",".jpg",".jpeg",".gif",".bmp",".tiff",".tif",".svg",".webp",".heic"
    };

    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IHttpContextAccessor _contextAccessor;
    public FileService(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor contextAccessor)
    {
        _webHostEnvironment = webHostEnvironment;
        _contextAccessor = contextAccessor;
    }

    public async Task<UploadFileResultDto> UploadFileAsync(IFormFile file, string storageName)
    {

        if (file is null || file.Length <= 0 || file.Length >= ((1024 * 1024) * 4))
            throw new InvalidImageSizeException("Invalid Image Size !");

        if (!allowedExtension.Contains(Path.GetExtension(file.FileName).ToLower()))
            throw new InvalidImageSizeException("Invalid Image Extension !");

        string path = $"{_webHostEnvironment.WebRootPath}/{storageName}/";
        string extension = Path.GetExtension(file.FileName);
        string fileName = $"{Guid.NewGuid().ToString().Replace("-", string.Empty)}{extension}";

        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        using FileStream stream = File.Create($"{path}{fileName}");
        await file.CopyToAsync(stream);
        await stream.FlushAsync();

        HttpRequest httpRequest = _contextAccessor.HttpContext.Request;

        return new UploadFileResultDto()
        {
            Success = true,
            ContentType = file.ContentType,
            FileName = fileName,
            FilePath = $"{httpRequest.Scheme}://{httpRequest.Host}/{storageName}/{fileName}"
        };
    }

    public Task<bool> DeleteFileAsync(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
                return Task.FromResult(false);

            File.Delete(filePath);

            return Task.FromResult(true);
        }
        catch
        {
            throw new InvalidDeleteImageException("Deleted File Process Fail !");
        }
    }
}
