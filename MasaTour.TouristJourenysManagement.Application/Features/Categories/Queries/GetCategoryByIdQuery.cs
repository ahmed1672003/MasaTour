namespace MasaTour.TouristJourenysManagement.Application.Features.Categories.Queries;
public sealed record GetCategoryByIdQuery(string categoryId) : IRequest<ResponseModel<GetCategoryDto>>;

