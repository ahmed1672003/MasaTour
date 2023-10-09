namespace MasaTour.TouristTripsManagement.Application.Features.Transportations.Commands;
public sealed record UndoDeleteTransportationByIdCommand(string TransportationId) : IRequest<ResponseModel<GetTransportationDto>>;
