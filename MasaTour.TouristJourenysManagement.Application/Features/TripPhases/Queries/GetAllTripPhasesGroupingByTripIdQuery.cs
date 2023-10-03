namespace MasaTour.TouristTripsManagement.Application.Features.TripPhases.Queries;
public sealed record GetAllTripPhasesGroupingByTripIdQuery() : IRequest<ResponseModel<IEnumerable<GetTripPhaseDto>>>;
