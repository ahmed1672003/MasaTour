namespace MasaTour.TouristTripsManagement.Application.Features.TransportationClasses.Queries;
public sealed record GetAllTransportationClassesQuery() : IRequest<ResponseModel<IEnumerable<GetTransportationClassDto>>>;


