using MasaTour.TouristTripsManagement.Services.Dtos.Auth;
namespace MasaTour.TouristTripsManagement.Services.Services.Contracts;
public interface ICookiesService
{
    Task SaveAuthInformationsAsync(AuthModel authModel);
    Task<(string jwt, string refreshToken)> GetAuthInformationsAsync();
    Task DeleteAuthInformationsAsync();
}
