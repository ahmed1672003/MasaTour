namespace MasaTour.TouristTripsManagement.Application.Features.TripPhases.Queries;
public sealed record GetAllTripPhasesByTripIdQuery([Required] string TripId) : IRequest<ResponseModel<IEnumerable<GetTripPhaseDto>>>;
