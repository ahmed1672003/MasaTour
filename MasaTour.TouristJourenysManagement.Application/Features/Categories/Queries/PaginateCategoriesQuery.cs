using MasaTour.TouristJourenysManagement.Application.Features.Enums;

namespace MasaTour.TouristJourenysManagement.Application.Features.Categories.Queries;
public sealed record PaginateCategoriesQuery(int? pageNumber = 1, int? pageSize = 1, CategoryOrderBy? orderBy = CategoryOrderBy.CreatedAt) : IRequest<PaginationResponseModel<IEnumerable<GetCategoryDto>>>;