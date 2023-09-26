namespace MasaTour.TouristTripsManagement.Application.Features.Categories.Queries;
public sealed record GetAllActiveCategoriesQuery() : IRequest<ResponseModel<IEnumerable<GetCategoryDto>>>;
