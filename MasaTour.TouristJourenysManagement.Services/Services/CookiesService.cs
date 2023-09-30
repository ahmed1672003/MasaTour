using MasaTour.TouristTripsManagement.Services.Dtos.Auth;

using Microsoft.AspNetCore.Http;

namespace MasaTour.TouristTripsManagement.Services.Services;
public sealed class CookiesService : ICookiesService
{
    private readonly IHttpContextAccessor _contextAccessor;

    public CookiesService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public Task SaveAuthInformationsAsync(AuthModel authModel)
    {
        _contextAccessor.HttpContext.Response.Cookies.Append("jwt", authModel.JWTModel.JWT);
        _contextAccessor.HttpContext.Response.Cookies.Append("jwtExpirationDate", authModel.JWTModel.JWTExpirationDate.ToShortDateString());
        _contextAccessor.HttpContext.Response.Cookies.Append("refreshToken", authModel.RefreshJWTModel.RefreshJWT);
        _contextAccessor.HttpContext.Response.Cookies.Append("refreshJwtExpirationDate", authModel.RefreshJWTModel.RefreshJWTExpirationDate.ToShortDateString());
        return Task.CompletedTask;
    }

    public Task<(string jwt, string refreshToken)> GetAuthInformationsAsync()
    {
        return Task.FromResult((_contextAccessor.HttpContext.Request.Cookies["jwt"], _contextAccessor.HttpContext.Request.Cookies["refreshToken"]));
    }

    public Task DeleteAuthInformationsAsync()
    {
        _contextAccessor.HttpContext.Response.Cookies.Delete("jwt");
        _contextAccessor.HttpContext.Response.Cookies.Delete("jwtExpirationDate");
        _contextAccessor.HttpContext.Response.Cookies.Delete("refreshToken");
        _contextAccessor.HttpContext.Response.Cookies.Delete("refreshJwtExpirationDate");
        return Task.CompletedTask;
    }
}
