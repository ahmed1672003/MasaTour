namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.TripPhases;
public sealed class AsNoTrackingGetAllTripPhasesSpecification : Specification<TripPhase>
{
    public AsNoTrackingGetAllTripPhasesSpecification()
    {
        StopTracking();
        AddOrderBy(tp => tp.PhaseNumber);
    }
}
