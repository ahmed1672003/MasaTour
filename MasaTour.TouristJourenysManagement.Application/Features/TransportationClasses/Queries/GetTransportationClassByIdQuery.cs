namespace MasaTour.TouristTripsManagement.Application.Features.TransportationClasses.Queries;
public sealed record GetTransportationClassByIdQuery(string ClassId) : IRequest<ResponseModel<GetTransportationClassDto>>;
