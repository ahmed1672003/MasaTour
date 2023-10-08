namespace MasaTour.TouristTripsManagement.Application.Features.TransportationClasses.Commands;
public sealed record UpdateTransportationClassCommand(UpdateTransportationClassDto Dto) : IRequest<ResponseModel<GetTransportationClassDto>>;

