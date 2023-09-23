using System.Net.Mail;

namespace MasaTour.TouristJourenysManagement.Application.Features.Auth.Mappers;
public class AuthProfile : Profile
{
    public AuthProfile()
    {
        Mapp();
    }
    void Mapp()
    {
        CreateMap<AddUserDto, User>().ForMember(dist => dist.UserName, cfg => cfg.MapFrom(src => new MailAddress(src.Email).User));
        CreateMap<User, GetUserDto>().ForMember(dist => dist.CreatedAt, cfg => cfg.MapFrom(src => src.CreatedAt.ToShortDateString()));
        CreateMap<User, GetUserDto>().ForMember(dist => dist.UpdatedAt, cfg => cfg.MapFrom(src => src.UpdatedAt.ToShortDateString()));
        CreateMap<User, GetUserDto>().ForMember(dist => dist.DeletedAt, cfg => cfg.MapFrom(src => src.DeletedAt.Value.ToShortDateString()));
    }
}

