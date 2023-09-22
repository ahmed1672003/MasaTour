namespace MasaTour.TouristJourenysManagement.Services.Services;
public class UnitOfSevices : IUnitOfServices
{
    public UnitOfSevices(IAuthService authService, ICookiesService cookiesService)
    {
        AuthService = authService;
        CookiesService = cookiesService;
    }

    public IAuthService AuthService { get; }
    public ICookiesService CookiesService { get; }
}
