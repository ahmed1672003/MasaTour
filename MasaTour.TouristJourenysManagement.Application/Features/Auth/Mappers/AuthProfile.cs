using System.Net.Mail;

namespace MasaTour.TouristTripsManagement.Application.Features.Auth.Mappers;
public class AuthProfile : Profile
{
    public AuthProfile()
    {
        Mapp();
    }
    void Mapp()
    {
        CreateMap<AddUserDto, User>().ForMember(dist => dist.UserName, cfg => cfg.MapFrom(src => new MailAddress(src.Email).User));
        CreateMap<User, GetUserDto>();
    }
}

