namespace MasaTour.TouristTripsManagement.Application.Features.Categories.Queries;
public sealed record GetAllCategoriesQuery() : IRequest<ResponseModel<IEnumerable<GetCategoryDto>>>;

