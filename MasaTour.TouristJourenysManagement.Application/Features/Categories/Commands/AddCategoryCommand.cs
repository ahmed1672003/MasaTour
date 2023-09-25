namespace MasaTour.TouristJourenysManagement.Application.Features.Categories.Commands;
public sealed record AddCategoryCommand(AddCategoryDto dto) : IRequest<ResponseModel<GetCategoryDto>>;

