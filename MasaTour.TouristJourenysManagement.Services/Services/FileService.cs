using MasaTour.TouristTripsManagement.Services.Dtos.Files;

namespace MasaTour.TouristTripsManagement.Services.Services;
public sealed class FileService : IFileService
{
    private static string[] allowedExtension = new string[]
    {
            ".png",".jpg",".jpeg",".gif",".bmp",".tiff",".tif",".svg",".webp",".heic"
    };

    private readonly IWebHostEnvironment _webHostEnvironment;
    public FileService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<UploadFileResultDto> UploadFileAsync(IFormFile imgFile, string storageName)
    {
        if (imgFile is null || imgFile.Length <= 0 || imgFile.Length >= ((1024 * 1024) * 10))
            throw new InvalidImageSizeException("Invalid Image Size !");

        if (!allowedExtension.Contains(Path.GetExtension(imgFile.FileName).ToLower()))
            throw new InvalidImageSizeException("Invalid Image Extension !");

        try
        {
            string storagePath = Path.Combine(_webHostEnvironment.WebRootPath, storageName);

            if (!Directory.Exists(storagePath))
                Directory.CreateDirectory(storagePath);

            string fileName = Guid.NewGuid().ToString() + "_" + imgFile.FileName;
            string fullPath = Path.Combine(storagePath, fileName);

            using var stream = new FileStream(fullPath, FileMode.Create);
            await imgFile.CopyToAsync(stream);

            if (!File.Exists(fullPath))
                throw new InvalidUploadImageException("Invalid Upload Image !");

            return new()
            {
                FileName = fileName,
                FilePath = fullPath,
                ContentType = imgFile.ContentType,
                Success = true,
            };
        }
        catch
        {
            return new()
            {
                Success = false
            };
        }
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
