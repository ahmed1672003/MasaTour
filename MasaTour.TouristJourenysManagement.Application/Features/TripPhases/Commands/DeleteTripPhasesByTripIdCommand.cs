namespace MasaTour.TouristTripsManagement.Application.Features.TripPhases.Commands;

public sealed record DeleteTripPhasesByTripIdCommand(string TripId) : IRequest<ResponseModel<GetTripPhaseDto>>;
