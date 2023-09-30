namespace MasaTour.TouristTripsManagement.Application.Features.Trips.Queries;
public sealed record PaginateDeletedTripsQuery(int? PageNumber = 1, int? PageSize = 10, string KeyWorks = "", TripOrderBy? orderBy = TripOrderBy.CreatedAt) : IRequest<PaginationResponseModel<IEnumerable<GetTripDto>>>;
