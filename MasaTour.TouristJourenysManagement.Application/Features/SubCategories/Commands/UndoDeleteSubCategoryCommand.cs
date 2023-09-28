namespace MasaTour.TouristTripsManagement.Application.Features.SubCategories.Commands;
public sealed record UndoDeleteSubCategoryCommand(string subCategoryId) : IRequest<ResponseModel<GetSubCategoryDto>>;


