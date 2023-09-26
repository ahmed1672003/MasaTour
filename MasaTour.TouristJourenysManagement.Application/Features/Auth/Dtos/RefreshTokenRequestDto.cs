namespace MasaTour.TouristTripsManagement.Application.Features.Auth.Dtos;
public class RefreshTokenRequestDto
{
    public string? JWT { get; set; }
    public string? RefreshToken { get; set; }
}
