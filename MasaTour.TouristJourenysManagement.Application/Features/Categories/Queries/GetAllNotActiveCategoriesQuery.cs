namespace MasaTour.TouristTripsManagement.Application.Features.Categories.Queries;
public sealed record GetAllNotActiveCategoriesQuery() : IRequest<ResponseModel<IEnumerable<GetCategoryDto>>>;
