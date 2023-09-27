using MasaTour.TouristTripsManagement.Application.Features.SubCategories.Dtos;

namespace MasaTour.TouristTripsManagement.Application.Features.SubCategories.Mappers;
public class SubCategoryProfile : Profile
{
    public SubCategoryProfile()
    {
        Mapp();
    }
    void Mapp()
    {
        CreateMap<AddSubCategoryDto, SubCategory>();
        CreateMap<SubCategory, GetSubCategoryDto>()
            .ForMember(dist => dist.SubCategoryId, cfg => cfg.MapFrom(src => src.Id))
            .ForMember(dist => dist.CreatedAt, cfg => cfg.MapFrom(src => src.CreatedAt.ToLocalTime()))
            .ForMember(dist => dist.SubCategoryId, cfg => cfg.MapFrom(src => src.UpdatedAt.Value.ToLocalTime()))
            .ForMember(dist => dist.SubCategoryId, cfg => cfg.MapFrom(src => src.DeletedAt.Value.ToLocalTime()));
    }
}
