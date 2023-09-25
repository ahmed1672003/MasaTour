namespace MasaTour.TouristJourenysManagement.Application.Features.Categories.Queries;
public sealed record GetAllCategoriesQuery() : IRequest<ResponseModel<IEnumerable<GetCategoryDto>>>;

