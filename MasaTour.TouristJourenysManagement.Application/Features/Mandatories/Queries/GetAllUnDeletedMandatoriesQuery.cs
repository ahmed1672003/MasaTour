namespace MasaTour.TouristTripsManagement.Application.Features.Mandatories.Queries;
public sealed record GetAllUnDeletedMandatoriesQuery() : IRequest<ResponseModel<IEnumerable<GetMandatoryDto>>>;