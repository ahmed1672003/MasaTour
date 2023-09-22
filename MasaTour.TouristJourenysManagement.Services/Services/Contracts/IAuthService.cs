using MasaTour.TouristJourenysManagement.Services.Dtos.Auth;

namespace MasaTour.TouristJourenysManagement.Services.Services.Contracts;
public interface IAuthService
{
    Func<string, JwtSecurityToken, Task<bool>> IsJWTValid { get; }
    Task<AuthModel> GetJWTAsync(User user);
    Task<JwtSecurityToken> ReadJWTAsync(string jwt);
    Task<AuthModel> RefreshJWTAsync(User user);
}
