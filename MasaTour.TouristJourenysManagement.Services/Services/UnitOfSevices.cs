namespace MasaTour.TouristTripsManagement.Services.Services;
public sealed class UnitOfSevices : IUnitOfServices
{
    public UnitOfSevices(
        IAuthService authService,
        ICookiesService cookiesService,
        IEmailService emailService,
        IFastForexService fastForexService,
        IFileService fileService)
    {
        AuthService = authService;
        CookiesService = cookiesService;
        EmailService = emailService;
        FastForexService = fastForexService;
        FileService = fileService;
    }
    public IAuthService AuthService { get; }
    public ICookiesService CookiesService { get; }
    public IEmailService EmailService { get; }
    public IFastForexService FastForexService { get; }
    public IFileService FileService { get; }
}
