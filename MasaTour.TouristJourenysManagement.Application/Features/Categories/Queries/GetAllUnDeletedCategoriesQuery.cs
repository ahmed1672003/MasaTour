namespace MasaTour.TouristJourenysManagement.Application.Features.Categories.Queries;
public record class GetAllUnDeletedCategoriesQuery() : IRequest<ResponseModel<IEnumerable<GetCategoryDto>>>;

