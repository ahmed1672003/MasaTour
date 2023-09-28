using MasaTour.TouristTripsManagement.Domain.Mandatories.Dtos;

namespace MasaTour.TouristTripsManagement.Application.Features.Mandatories.Commands;
public sealed record AddMandatoryCommand(AddMandatoryDto dto) : IRequest<ResponseModel<GetMandatoryDto>>;
