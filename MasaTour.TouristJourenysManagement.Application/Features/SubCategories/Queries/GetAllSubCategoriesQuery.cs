namespace MasaTour.TouristTripsManagement.Application.Features.SubCategories.Queries;
public sealed record GetAllSubCategoriesQuery() : IRequest<ResponseModel<IEnumerable<GetSubCategoryDto>>>;
