using MasaTour.TouristTripsManagement.Application.Features.SubCategories.Dtos;

namespace MasaTour.TouristTripsManagement.Application.Features.SubCategories.Commands;
public sealed record DeleteSubCategoryCommand([Required] string subCategoryId) : IRequest<ResponseModel<GetSubCategoryDto>>;
