namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Trips;
public sealed class AsNoTrackingGetTripByNameDESpecification : Specification<Trip>
{
    public AsNoTrackingGetTripByNameDESpecification(string nameDE) : base(j => j.NameDE.Equals(nameDE))
    {
        StopTracking();
    }
}
