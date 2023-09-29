using Microsoft.AspNetCore.Http;

namespace MasaTour.TouristTripsManagement.Services.Services.Contracts;
public interface IFileService
{
    Task<string> UploadFile(IEnumerable<IFormFile> files);
}
