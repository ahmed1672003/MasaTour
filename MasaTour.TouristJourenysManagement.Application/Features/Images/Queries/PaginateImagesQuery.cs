namespace MasaTour.TouristTripsManagement.Application.Features.Images.Queries;
public sealed record PaginateImagesQuery(int? PageNumber = 1, int? PageSize = 10, ImageOrderBy? OrderBy = ImageOrderBy.CreatedAt) : IRequest<PaginationResponseModel<IEnumerable<GetImageDto>>>;


