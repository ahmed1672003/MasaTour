namespace MasaTour.TouristTripsManagement.Application.Features.TransportationClasses.Commands;
public sealed record DeleteTransportationClassByIdCommand(string ClassId) : IRequest<ResponseModel<GetTransportationClassDto>>;

