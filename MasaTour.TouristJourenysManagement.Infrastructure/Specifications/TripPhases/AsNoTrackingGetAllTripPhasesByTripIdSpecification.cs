namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.TripPhases;
public sealed class AsNoTrackingGetAllTripPhasesByTripIdSpecification : Specification<TripPhase>
{
    public AsNoTrackingGetAllTripPhasesByTripIdSpecification(string tripId) : base(t => t.TripId.Equals(tripId))
    {
        StopTracking();
        AddOrderBy(tp => tp.PhaseNumber);
    }
}
