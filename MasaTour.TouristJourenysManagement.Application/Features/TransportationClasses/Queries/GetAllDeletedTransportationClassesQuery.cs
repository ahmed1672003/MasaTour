namespace MasaTour.TouristTripsManagement.Application.Features.TransportationClasses.Queries;
public sealed record GetAllDeletedTransportationClassesQuery() : IRequest<ResponseModel<IEnumerable<GetTransportationClassDto>>>;
