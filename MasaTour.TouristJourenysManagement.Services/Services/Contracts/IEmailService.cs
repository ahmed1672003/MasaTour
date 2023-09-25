using MasaTour.TouristJourenysManagement.Services.Dtos.Messages;

using Microsoft.AspNetCore.Http;

namespace MasaTour.TouristJourenysManagement.Services.Services.Contracts;
public interface IEmailService
{
    Task<SendEmailDto> SendEmailAsync(string mailTo, string subject, string body, IReadOnlyList<IFormFile> attachments = null);

}
