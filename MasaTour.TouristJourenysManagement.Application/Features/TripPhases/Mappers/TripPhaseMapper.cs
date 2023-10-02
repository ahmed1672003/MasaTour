using MasaTour.TouristTripsManagement.Application.Features.TripPhases.Dtos;

namespace MasaTour.TouristTripsManagement.Application.Features.TripPhases.Mappers;
public sealed class TripPhaseMapper : Profile
{
    public TripPhaseMapper()
    {
        Map();
    }

    void Map()
    {
        CreateMap<AddTripPhaseDto, TripPhase>()
            .ForMember(dist => dist.FromClock, cfg => cfg.MapFrom(src => new TimeSpan(src.FromHours, src.FromMinutes, 0)))
            .ForMember(dist => dist.ToClock, cfg => cfg.MapFrom(src => new TimeSpan(src.ToHours, src.ToMinutes, 0)));


        CreateMap<TripPhase, GetTripPhaseDto>()
            .ForMember(dist => dist.CreatedAt, cfg => cfg.MapFrom(src => src.CreatedAt.ToLocalTime()))
            .ForMember(dist => dist.UpdatedAt, cfg => cfg.MapFrom(src => src.UpdatedAt.Value.ToLocalTime()))
            .ForMember(dist => dist.DeletedAt, cfg => cfg.MapFrom(src => src.DeletedAt.Value.ToLocalTime()))
            .ForMember(dist => dist.TripPhaseId, cfg => cfg.MapFrom(src => src.Id));
    }
}
