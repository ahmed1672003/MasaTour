namespace MasaTour.TouristTripsManagement.Application.Features.Trips.Queries;
public sealed record GetTripByIdQuery(string Id) : IRequest<ResponseModel<GetTripDto>>;

