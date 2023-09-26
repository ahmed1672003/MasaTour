namespace MasaTour.TouristTripsManagement.Application.Features.Trips.Queries;
public sealed record GetAllFamousTripsQuery() : IRequest<ResponseModel<IEnumerable<GetTripDto>>>;