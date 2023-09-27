namespace MasaTour.TouristTripsManagement.Application.Features.Trips.Mappers;
public class TripProfile : Profile
{
    public TripProfile()
    {
        Map();
    }
    void Map()
    {
        CreateMap<AddTripDto, Trip>();
        CreateMap<Trip, GetTripDto>()
            .ForMember(dist => dist.CreatedAt, cfg => cfg.MapFrom(src => src.CreatedAt.ToLocalTime()))
            .ForMember(dist => dist.UpdatedAt, cfg => cfg.MapFrom(src => src.UpdatedAt.Value.ToLocalTime()))
            .ForMember(dist => dist.DeletedAt, cfg => cfg.MapFrom(src => src.DeletedAt.Value.ToLocalTime()));
    }
}
