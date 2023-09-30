using MasaTour.TouristTripsManagement.Services.Dtos.Files;

namespace MasaTour.TouristTripsManagement.Services.Services.Contracts;
public interface IFileService
{
    Task<UploadFileResultDto> UploadFileAsync(IFormFile imgFile, string storageName);

    Task<bool> DeleteFileAsync(string filePath);
}
