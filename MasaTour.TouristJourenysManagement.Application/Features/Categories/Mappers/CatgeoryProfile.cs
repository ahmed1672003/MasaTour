namespace MasaTour.TouristTripsManagement.Application.Features.Categories.Mappers;
public sealed class CatgeoryProfile : Profile
{
    public CatgeoryProfile()
    {
        Mapp();
    }
    void Mapp()
    {
        CreateMap<AddCategoryDto, Category>();
        CreateMap<Category, GetCategoryDto>()
            .ForMember(dist => dist.CategoryId, cfg => cfg.MapFrom(src => src.Id))
            .ForMember(dist => dist.CreatedAt, cfg => cfg.MapFrom(src => src.CreatedAt.ToLocalTime()))
            .ForMember(dist => dist.UpdatedAt, cfg => cfg.MapFrom(src => src.UpdatedAt.Value.ToLocalTime()))
            .ForMember(dist => dist.DeletedAt, cfg => cfg.MapFrom(src => src.DeletedAt.Value.ToLocalTime()));
    }
}
