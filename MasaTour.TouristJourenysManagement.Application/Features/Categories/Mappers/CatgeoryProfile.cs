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
        CreateMap<Category, GetCategoryDto>();
    }
}
