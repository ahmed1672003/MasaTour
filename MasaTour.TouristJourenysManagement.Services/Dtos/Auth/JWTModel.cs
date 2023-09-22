namespace MasaTour.TouristJourenysManagement.Services.Dtos.Auth;

public class JWTModel
{
    public string JWT { get; set; }
    public DateTime JWTExpirationDate { get; set; }
}