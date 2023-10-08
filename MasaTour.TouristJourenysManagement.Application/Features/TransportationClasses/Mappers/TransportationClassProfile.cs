namespace MasaTour.TouristTripsManagement.Application.Features.TransportationClasses.Mappers;
public sealed class TransportationClassProfile : Profile
{
    public TransportationClassProfile()
    {
        Map();
    }
    void Map()
    {
        CreateMap<AddTransportationClassDto, TransporationClass>();
        CreateMap<TransporationClass, GetTransportationClassDto>()
            .ForMember(dist => dist.TrasportationClassId, cfg => cfg.MapFrom(src => src.Id))
            .ForMember(dist => dist.CreatedAt, cfg => cfg.MapFrom(src => src.CreatedAt.ToLocalTime()))
            .ForMember(dist => dist.UpdatedAt, cfg => cfg.MapFrom(src => src.UpdatedAt.Value.ToLocalTime()))
            .ForMember(dist => dist.DeletedAt, cfg => cfg.MapFrom(src => src.DeletedAt.Value.ToLocalTime()));
    }
}
