using MasaTour.TouristJourenysManagement.Services.Dtos.Auth;
namespace MasaTour.TouristJourenysManagement.Services.Services.Contracts;
public interface ICookiesService
{
    Task SaveAuthInformationsAsync(AuthModel authModel);
    Task<(string jwt, string refreshToken)> GetAuthInformationsAsync();
    Task DeleteAuthInformationsAsync();
}
