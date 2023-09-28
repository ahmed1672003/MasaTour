namespace MasaTour.TouristTripsManagement.Application.Features.Mandatories.Commands;
public sealed record UpdateMandatoryCommand(UpdateMandatoryDto dto) : IRequest<ResponseModel<GetMandatoryDto>>;
