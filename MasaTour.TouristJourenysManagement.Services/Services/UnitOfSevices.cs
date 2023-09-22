namespace MasaTour.TouristJourenysManagement.Services.Services;
public class UnitOfSevices : IUnitOfServices
{
    public UnitOfSevices(IAuthService authService)
    {
        AuthService = authService;
    }

    public IAuthService AuthService { get; }
}
