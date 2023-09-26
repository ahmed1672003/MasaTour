namespace MasaTour.TouristTripsManagement.Application.Features.Trips.Queries;
public sealed record GetAllTripsQuery() : IRequest<ResponseModel<IEnumerable<GetTripDto>>>;
