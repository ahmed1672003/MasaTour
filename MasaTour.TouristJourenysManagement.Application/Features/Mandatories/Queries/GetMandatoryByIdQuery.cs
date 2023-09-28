namespace MasaTour.TouristTripsManagement.Application.Features.Mandatories.Queries;
public sealed record GetMandatoryByIdQuery([Required] string Id) : IRequest<ResponseModel<GetMandatoryDto>>;
