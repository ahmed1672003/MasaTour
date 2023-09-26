namespace MasaTour.TouristTripsManagement.Application.Features.Trips.Queries;
public sealed record GetAllDeletedTripsQuery() : IRequest<ResponseModel<IEnumerable<GetTripDto>>>;
