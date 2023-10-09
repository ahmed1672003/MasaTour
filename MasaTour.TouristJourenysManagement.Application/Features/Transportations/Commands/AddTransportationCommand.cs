using MasaTour.TouristTripsManagement.Application.Features.Transportations.Dtos;

namespace MasaTour.TouristTripsManagement.Application.Features.Transportations.Commands;
public sealed record AddTransportationCommand(AddTransportationDto Dto) : IRequest<ResponseModel<GetTransportationDto>>;
