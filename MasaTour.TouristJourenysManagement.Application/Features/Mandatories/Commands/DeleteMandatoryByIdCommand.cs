namespace MasaTour.TouristTripsManagement.Application.Features.Mandatories.Commands;
public sealed record DeleteMandatoryByIdCommand([Required] string Id) : IRequest<ResponseModel<GetMandatoryDto>>;
