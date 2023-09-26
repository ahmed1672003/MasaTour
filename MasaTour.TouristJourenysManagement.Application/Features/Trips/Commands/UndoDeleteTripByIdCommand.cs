namespace MasaTour.TouristTripsManagement.Application.Features.Trips.Commands;
public sealed record UndoDeleteTripByIdCommand([Required] string Id) : IRequest<ResponseModel<GetTripDto>>;

