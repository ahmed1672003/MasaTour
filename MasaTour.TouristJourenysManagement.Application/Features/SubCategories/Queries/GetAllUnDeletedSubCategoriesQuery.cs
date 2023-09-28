namespace MasaTour.TouristTripsManagement.Application.Features.SubCategories.Queries;
public sealed record GetAllUnDeletedSubCategoriesQuery : IRequest<ResponseModel<IEnumerable<GetSubCategoryDto>>>;
