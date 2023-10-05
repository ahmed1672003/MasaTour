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

        CreateMap<TripImageMapper, GetTripImagesDto>()
            .ForMember(dist => dist.ImageId, cfg => cfg.MapFrom(src => src.Image.Id))
            .ForMember(dist => dist.ContentType, cfg => cfg.MapFrom(src => src.Image.ContentType))
            .ForMember(dist => dist.FilePath, cfg => cfg.MapFrom(src => src.Image.FilePath))
            .ForMember(dist => dist.IsCover, cfg => cfg.MapFrom(src => src.IsCover))
            .ForMember(dist => dist.CreatedAt, cfg => cfg.MapFrom(src => src.Image.CreatedAt));

    }
}
