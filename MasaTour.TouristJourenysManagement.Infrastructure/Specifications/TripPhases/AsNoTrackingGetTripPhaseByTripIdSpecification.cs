namespace MasaTour.TouristTripsManagement.Application.Features.TripPhases.Commands.Handler;
public sealed class AsNoTrackingGetTripPhaseByTripIdSpecification : Specification<TripPhase>
{
    public AsNoTrackingGetTripPhaseByTripIdSpecification(string tripId)
        : base(t => t.TripId.Equals(tripId))
    {
        StopTracking();
    }
}
