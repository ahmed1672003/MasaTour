namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.TripPhases;
public sealed class AsTrackingGetTripPhaseSpecification : Specification<TripPhase>
{
    public AsTrackingGetTripPhaseSpecification(string tripPhaseId)
        : base(tp => tp.Id.Equals(tripPhaseId))
    {

    }
}