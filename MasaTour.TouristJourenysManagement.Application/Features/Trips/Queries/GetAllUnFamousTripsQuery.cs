namespace MasaTour.TouristTripsManagement.Application.Features.Trips.Queries;
public sealed record GetAllUnFamousTripsQuery() : IRequest<ResponseModel<IEnumerable<GetTripDto>>>;
