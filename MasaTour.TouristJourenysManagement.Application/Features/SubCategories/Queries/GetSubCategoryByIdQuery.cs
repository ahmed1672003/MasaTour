namespace MasaTour.TouristTripsManagement.Application.Features.SubCategories.Queries;
public sealed record GetSubCategoryByIdQuery([Required] string subCategoryId) : IRequest<ResponseModel<GetSubCategoryDto>>;
