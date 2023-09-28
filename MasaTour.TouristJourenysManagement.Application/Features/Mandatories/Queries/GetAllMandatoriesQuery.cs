namespace MasaTour.TouristTripsManagement.Application.Features.Mandatories.Queries;
public sealed record GetAllMandatoriesQuery() : IRequest<ResponseModel<IEnumerable<GetMandatoryDto>>>;