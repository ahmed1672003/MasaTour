namespace MasaTour.TouristTripsManagement.Application.Features.Trips.Queries;
public sealed record GetAllNotActiveTripsQuery() : IRequest<ResponseModel<IEnumerable<GetTripDto>>>;
