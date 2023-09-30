using MasaTour.TouristTripsManagement.Domain.Exceptions.Image;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace MasaTour.TouristTripsManagement.Infrastructure.Repositories;
public sealed class ImageRepository : Repository<Image>, IImageRepository
{
    private static string[] allowedExtension = new string[]
    {
        ".png",".jpg","jpeg",".gif",".bmp",".tiff",".tif",".svg",".webp",".heic"
    };

    private readonly IWebHostEnvironment _webHostEnvironment;
    public ImageRepository(ITouristTripsManagementDbContext context, IWebHostEnvironment webHostEnvironment) : base(context)
    {
        _webHostEnvironment = webHostEnvironment;
    }
    public async Task<string> UploadImageAsync(IFormFile imgFile)
    {
        if (imgFile is null || imgFile.Length <= 0 || imgFile.Length >= ((1024 * 1024) * 1))
            throw new InvalidImageSizeException("Invalid Image Size !");

        if (!allowedExtension.Contains(Path.GetExtension(imgFile.FileName).ToLower()))
            throw new InvalidImageSizeException("Invalid Image Extension !");

        try
        {
            string fileName = "Gallery" + Guid.NewGuid().ToString() + "_" + imgFile.FileName;
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, fileName);
            using var stream = new FileStream(filePath, FileMode.Create);
            await imgFile.CopyToAsync(stream);

            if (!File.Exists(filePath))
                throw new InvalidUploadImageException("Invalid Upload Image !");
            return filePath;
        }
        catch
        {
            return null;
        }
    }
}
