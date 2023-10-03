namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Trips;
public sealed class AsTrackingGetTripById_TripPhases_Specification : Specification<Trip>
{
    public AsTrackingGetTripById_TripPhases_Specification(string id)
        : base(t => t.Id.Equals(id))
    {
        IgnorQueryFilter();
        AddIncludes(t => t.TripPhases);
    }
}
