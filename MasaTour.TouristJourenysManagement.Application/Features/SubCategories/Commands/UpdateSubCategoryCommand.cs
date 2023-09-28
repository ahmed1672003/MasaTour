using MasaTour.TouristTripsManagement.Application.Features.SubCategories.Dtos;

namespace MasaTour.TouristTripsManagement.Application.Features.SubCategories.Commands;
public sealed record UpdateSubCategoryCommand(UpdateSubCategoryDto dto) : IRequest<ResponseModel<GetSubCategoryDto>>;