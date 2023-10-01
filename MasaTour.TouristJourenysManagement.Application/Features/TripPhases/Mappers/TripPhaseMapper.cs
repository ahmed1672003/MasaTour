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
        CreateMap<AddTripPhaseDto, TripPhase>();

        CreateMap<TripPhase, GetTripPhaseDto>()
            .ForMember(dist => dist.CreatedAt, cfg => cfg.MapFrom(src => src.CreatedAt.ToLocalTime()))
            .ForMember(dist => dist.UpdatedAt, cfg => cfg.MapFrom(src => src.UpdatedAt.Value.ToLocalTime()))
            .ForMember(dist => dist.DeletedAt, cfg => cfg.MapFrom(src => src.DeletedAt.Value.ToLocalTime()))
            .ForMember(dist => dist.TripPhaseId, cfg => cfg.MapFrom(src => src.Id));
    }
}
