
namespace MasaTour.TouristTripsManagement.Application.Features.Transportations.Commands;
public sealed record DeleteTransportationByIdCommand(string TransportationId) : IRequest<ResponseModel<GetTransportationDto>>;
