namespace MasaTour.TouristTripsManagement.Application.Features.TransportationClasses.Commands;
public sealed record AddTransportationClassCommand(AddTransportationClassDto Dto) : IRequest<ResponseModel<GetTransportationClassDto>>;

