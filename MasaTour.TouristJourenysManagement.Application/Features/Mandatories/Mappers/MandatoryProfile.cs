using MasaTour.TouristTripsManagement.Domain.Mandatories.Dtos;

namespace MasaTour.TouristTripsManagement.Application.Features.Mandatories.Mappers;
public sealed class MandatoryProfile : Profile
{
    public MandatoryProfile()
    {
        Mapp();
    }

    void Mapp()
    {
        CreateMap<AddMandatoryDto, Mandatory>();
        CreateMap<Mandatory, GetMandatoryDto>()
            .ForMember(dist => dist.MandatoryId, cfg => cfg.MapFrom(src => src.Id))
            .ForMember(dist => dist.CreatedAt, cfg => cfg.MapFrom(src => src.CreatedAt.ToLocalTime()))
            .ForMember(dist => dist.UpdatedAt, cfg => cfg.MapFrom(src => src.UpdatedAt.Value.ToLocalTime()))
            .ForMember(dist => dist.DeletedAt, cfg => cfg.MapFrom(src => src.DeletedAt.Value.ToLocalTime()));
    }
}
