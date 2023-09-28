namespace MasaTour.TouristTripsManagement.Application.Features.SubCategories.Queries;
public sealed record GetAllDeletedSubCategoriesQuery : IRequest<ResponseModel<IEnumerable<GetSubCategoryDto>>>;

