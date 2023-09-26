namespace MasaTour.TouristTripsManagement.Services.Services;
public class UnitOfSevices : IUnitOfServices
{
    public UnitOfSevices(IAuthService authService, ICookiesService cookiesService, IEmailService emailService)
    {
        AuthService = authService;
        CookiesService = cookiesService;
        EmailService = emailService;
    }

    public IAuthService AuthService { get; }
    public ICookiesService CookiesService { get; }
    public IEmailService EmailService { get; }
}
