namespace MasaTour.TouristJourenysManagement.Services.Dtos;
public class AuthModel
{
    public JWTModel JWTModel { get; set; }
    public RefreshJWTModel RefreshJWTModel { get; set; }
}
public class RefreshJWTModel
{
    public string RefreshJWT { get; set; }
    public DateTime RefreshJWTExpirationDate { get; set; }
}

public class JWTModel
{
    public string JWT { get; set; }
    public DateTime JWTExpirationDate { get; set; }
}