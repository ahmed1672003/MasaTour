namespace MasaTour.TouristTripsManagement.Application.Features.Trips.Queries;
public sealed record PaginateUnDeletedTripsQuery(int? pageNumber = 1, int? pageSize = 1, string keyWords = "", TripOrderBy orderBy = TripOrderBy.CreatedAt) : IRequest<PaginationResponseModel<IEnumerable<GetTripDto>>>;

