namespace MasaTour.TouristTripsManagement.Application.Features.TripPhases.Commands;
public sealed record DeleteTripPhaseByPhaseIdCommand(string PhaseId) : IRequest<ResponseModel<GetTripPhaseDto>>;
