namespace MasaTour.TouristTripsManagement.Application.Features.Transportations.Queries;
public sealed record GetTransportationByIdQuery(string TransportationId) : IRequest<ResponseModel<GetTransportationDto>>;

