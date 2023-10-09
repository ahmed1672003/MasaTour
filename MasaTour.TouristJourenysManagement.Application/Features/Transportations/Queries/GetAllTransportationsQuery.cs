namespace MasaTour.TouristTripsManagement.Application.Features.Transportations.Queries;
public sealed record GetAllTransportationsQuery() : IRequest<ResponseModel<IEnumerable<GetTransportationDto>>>;