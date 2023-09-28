namespace MasaTour.TouristTripsManagement.Application.Features.SubCategories.Queries;
public sealed record PaginateUnDeletedSubCategoriesQuery(int? pageNumber = 1, int pageSize = 10, string keyWords = "", SubCategoryOrderBy orderBy = SubCategoryOrderBy.CreatedAt)
    : IRequest<PaginationResponseModel<IEnumerable<GetSubCategoryDto>>>;
