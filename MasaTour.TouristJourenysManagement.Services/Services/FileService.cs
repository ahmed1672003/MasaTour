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

    public async Task<UploadFileResultDto> UploadFileAsync(IFormFile file, string storage)
    {
        try
        {
            if (file is null)
                throw new ArgumentNullException(nameof(file));

            string path = $"{_webHostEnvironment.WebRootPath}/{storage}/";
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
                FilePath = $"{httpRequest.Scheme}://{httpRequest.Host}/{storage}/{fileName}"
            };
        }
        catch (Exception ex)
        {
            return new UploadFileResultDto()
            {
                Success = false,
            };
        }
    }
    public Task<bool> IsFileExistAsync(string storage, string fileName)
    {
        return Task.FromResult(File.Exists($"{_webHostEnvironment.WebRootPath}/{storage}/{fileName}"));
    }
    public Task<bool> DeleteFileAsync(string storage, string fileName)
    {
        try
        {
            string path = $"{_webHostEnvironment.WebRootPath}/{storage}/{fileName}";
            if (!File.Exists(path))
                return Task.FromResult(false);

            File.Delete(path);

            return Task.FromResult(true);
        }
        catch
        {
            throw new InvalidDeleteImageException("Deleted File Process Fail !");
        }
    }
}
