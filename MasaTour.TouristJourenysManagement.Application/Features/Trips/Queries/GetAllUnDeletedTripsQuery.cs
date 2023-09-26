namespace MasaTour.TouristTripsManagement.Application.Features.Trips.Queries;
public sealed record GetAllUnDeletedTripsQuery() : IRequest<ResponseModel<IEnumerable<GetTripDto>>>;

