namespace MasaTour.TouristJourenysManagement.Application.Features.Categories.Queries;
public sealed record GetAllNotActiveCategoriesQuery() : IRequest<ResponseModel<IEnumerable<GetCategoryDto>>>;
