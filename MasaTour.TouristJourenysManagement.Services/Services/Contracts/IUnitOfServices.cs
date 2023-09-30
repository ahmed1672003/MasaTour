namespace MasaTour.TouristTripsManagement.Services.Services.Contracts;
public interface IUnitOfServices
{
    IAuthService AuthService { get; }
    ICookiesService CookiesService { get; }
    IEmailService EmailService { get; }
    IFastForexService FastForexService { get; }
    IFileService FileService { get; }
}
