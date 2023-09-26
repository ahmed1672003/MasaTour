namespace MasaTour.TouristTripsManagement.Application.Features.Trips.Commands;
public sealed record UndoDeleteTripByIdCommand([Required] string id) : IRequest<ResponseModel<GetTripDto>>;

