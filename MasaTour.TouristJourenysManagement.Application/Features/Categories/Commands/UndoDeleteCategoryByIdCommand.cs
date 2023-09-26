namespace MasaTour.TouristTripsManagement.Application.Features.Categories.Commands;
public sealed record UndoDeleteCategoryByIdCommand(string categoryId) : IRequest<ResponseModel<GetCategoryDto>>;