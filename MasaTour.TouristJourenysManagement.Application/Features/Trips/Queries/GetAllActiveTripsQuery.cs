namespace MasaTour.TouristTripsManagement.Application.Features.Trips.Queries;
public sealed record GetAllActiveTripsQuery() : IRequest<ResponseModel<IEnumerable<GetTripDto>>>;
