using MasaTour.TouristTripsManagement.Application.Features.Enums;

namespace MasaTour.TouristTripsManagement.Application.Features.Categories.Queries;
public sealed record PaginateCategoriesQuery(int? pageNumber = 1, int? pageSize = 1, string keyWords = "", CategoryOrderBy? orderBy = CategoryOrderBy.CreatedAt) : IRequest<PaginationResponseModel<IEnumerable<GetCategoryDto>>>;