using Microsoft.AspNetCore.Http;

namespace MasaTour.TouristTripsManagement.Infrastructure.Repositories.Contracts;
public interface IImageRepository : IRepository<Image>
{
    Task<string> UploadImageAsync(IFormFile imgFile);
}
