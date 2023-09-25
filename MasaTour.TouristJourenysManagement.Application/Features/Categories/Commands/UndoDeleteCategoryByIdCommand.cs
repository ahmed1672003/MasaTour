namespace MasaTour.TouristJourenysManagement.Application.Features.Categories.Commands;
public sealed record UndoDeleteCategoryByIdCommand(string categoryId) : IRequest<ResponseModel<GetCategoryDto>>;