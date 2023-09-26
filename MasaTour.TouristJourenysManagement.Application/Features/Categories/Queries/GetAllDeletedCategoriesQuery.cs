namespace MasaTour.TouristTripsManagement.Application.Features.Categories.Queries;
public sealed record GetAllDeletedCategoriesQuery() : IRequest<ResponseModel<IEnumerable<GetCategoryDto>>>;
