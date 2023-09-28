namespace MasaTour.TouristTripsManagement.Application.Features.Mandatories.Queries;
public sealed record GetAllDeletedMandatoriesQuery() : IRequest<ResponseModel<IEnumerable<GetMandatoryDto>>>;
