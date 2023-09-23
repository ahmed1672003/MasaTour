using MasaTour.TouristJourenysManagement.Application.Features.Users.Dtos;

namespace MasaTour.TouristJourenysManagement.Application.Features.Users.Mappers;
public class UserProfile : Profile
{
    public UserProfile()
    {
        Mapp();
    }
    void Mapp()
    {
        CreateMap<UpdateUserDto, User>()
            .ForMember(dist => dist.UpdatedAt, cfg => cfg.MapFrom(src => DateTime.Now))
            .ForMember(dist => dist.IsDeleted, cfg => cfg.MapFrom(src => false));
    }
}

