namespace MasaTour.TouristJourenysManagement.Application.Features.Auth.Dtos;
public class RevokeTokenRequestDto
{
    public string? JWT { get; set; }

    public string? RefreshToken { get; set; }
}