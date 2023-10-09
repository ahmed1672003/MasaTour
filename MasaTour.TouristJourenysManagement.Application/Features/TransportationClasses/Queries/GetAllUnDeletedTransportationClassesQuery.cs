namespace MasaTour.TouristTripsManagement.Application.Features.TransportationClasses.Queries;
public sealed record GetAllUnDeletedTransportationClassesQuery() : IRequest<ResponseModel<IEnumerable<GetTransportationClassDto>>>;
