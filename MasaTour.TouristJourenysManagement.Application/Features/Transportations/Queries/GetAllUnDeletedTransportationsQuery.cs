namespace MasaTour.TouristTripsManagement.Application.Features.Transportations.Queries;
public sealed record GetAllUnDeletedTransportationsQuery() : IRequest<ResponseModel<IEnumerable<GetTransportationDto>>>;
