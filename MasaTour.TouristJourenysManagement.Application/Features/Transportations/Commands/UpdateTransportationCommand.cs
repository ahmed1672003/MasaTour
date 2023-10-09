namespace MasaTour.TouristTripsManagement.Application.Features.Transportations.Commands;
public sealed record UpdateTransportationCommand(UpdateTransportationDto Dto) : IRequest<ResponseModel<GetTransportationDto>>;
