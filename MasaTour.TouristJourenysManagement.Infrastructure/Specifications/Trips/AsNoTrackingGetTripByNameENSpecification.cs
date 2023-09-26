namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Trips;
public sealed class AsNoTrackingGetTripByNameENSpecification : Specification<Trip>
{
    public AsNoTrackingGetTripByNameENSpecification(string nameEN) : base(j => j.NameEN.Equals(nameEN))
    {
        StopTracking();
    }
}
