namespace MasaTour.TouristTripsManagement.Services.Services;
public class UnitOfSevices : IUnitOfServices
{
    public UnitOfSevices(
        IAuthService authService,
        ICookiesService cookiesService,
        IEmailService emailService,
        IFastForexService fastForexService)
    {
        AuthService = authService;
        CookiesService = cookiesService;
        EmailService = emailService;
        FastForexService = fastForexService;
    }

    public IAuthService AuthService { get; }
    public ICookiesService CookiesService { get; }
    public IEmailService EmailService { get; }
    public IFastForexService FastForexService { get; }
}
