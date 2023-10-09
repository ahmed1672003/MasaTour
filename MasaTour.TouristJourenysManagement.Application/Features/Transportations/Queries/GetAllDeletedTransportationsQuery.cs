namespace MasaTour.TouristTripsManagement.Application.Features.Transportations.Queries;
public sealed record GetAllDeletedTransportationsQuery() : IRequest<ResponseModel<IEnumerable<GetTransportationDto>>>;
