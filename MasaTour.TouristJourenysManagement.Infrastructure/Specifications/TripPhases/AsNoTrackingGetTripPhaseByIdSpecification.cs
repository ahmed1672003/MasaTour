namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.TripPhases;
public sealed class AsNoTrackingGetTripPhaseByIdSpecification : Specification<TripPhase>
{
    public AsNoTrackingGetTripPhaseByIdSpecification(string tripPhaseId)
        : base(tp => tp.Id.Equals(tripPhaseId))
    {
        StopTracking();
    }
}
