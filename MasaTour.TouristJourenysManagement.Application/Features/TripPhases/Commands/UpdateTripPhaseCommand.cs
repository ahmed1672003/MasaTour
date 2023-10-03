using MasaTour.TouristTripsManagement.Application.Features.TripPhases.Dtos;

namespace MasaTour.TouristTripsManagement.Application.Features.TripPhases.Commands;
public sealed record UpdateTripPhaseCommand(UpdateTripPhaseDto Dto) : IRequest<ResponseModel<GetTripPhaseDto>>;