
namespace MasaTour.TouristTripsManagement.Application.Features.SubCategories.Commands;
public sealed record AddSubCategoryCommand(AddSubCategoryDto dto) : IRequest<ResponseModel<GetSubCategoryDto>>;
