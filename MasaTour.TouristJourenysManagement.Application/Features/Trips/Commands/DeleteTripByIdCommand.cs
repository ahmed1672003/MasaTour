namespace MasaTour.TouristTripsManagement.Application.Features.Trips.Commands;
public sealed record DeleteTripByIdCommand([Required] string Id) : IRequest<ResponseModel<GetTripDto>>;

