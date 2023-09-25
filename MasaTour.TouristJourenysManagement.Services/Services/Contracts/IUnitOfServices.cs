﻿namespace MasaTour.TouristJourenysManagement.Services.Services.Contracts;
public interface IUnitOfServices
{
    IAuthService AuthService { get; }
    ICookiesService CookiesService { get; }
    IEmailService EmailService { get; }
}
