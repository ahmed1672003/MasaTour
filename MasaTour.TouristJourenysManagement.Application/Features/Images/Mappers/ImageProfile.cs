namespace MasaTour.TouristTripsManagement.Application.Features.Images.Mappers;
public sealed class ImageProfile : Profile
{
    public ImageProfile()
    {
        Mapp();
    }
    void Mapp()
    {
        CreateMap<Image, GetImageDto>()
            .ForMember(dist => dist.ImageId, cfg => cfg.MapFrom(src => src.Id));
    }
}
