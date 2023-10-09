
using MasaTour.TouristTripsManagement.Application.Features.Transportations.Dtos;

namespace MasaTour.TouristTripsManagement.Application.Features.Transportations.Mappers;
public sealed class TransportationProfile : Profile
{
    public TransportationProfile()
    {
        Map();
    }

    private void Map()
    {
        CreateMap<AddTransportationDto, Transportation>();
        CreateMap<Transportation, GetTransportationDto>()
            .ForMember(dist => dist.TransportationId, cfg => cfg.MapFrom(src => src.Id))
            .ForMember(dist => dist.CreatedAt, cfg => cfg.MapFrom(src => src.CreatedAt))
            .ForMember(dist => dist.UpdatedAt, cfg => cfg.MapFrom(src => src.UpdatedAt.Value.ToLocalTime()))
            .ForMember(dist => dist.DeletedAt, cfg => cfg.MapFrom(src => src.DeletedAt.Value.ToLocalTime()));
    }
}
